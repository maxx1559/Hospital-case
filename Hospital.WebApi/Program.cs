using Hospital.Application;
using Hospital.Application.Rules;
using Hospital.Application.Rules.RuleObjects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppointmentDbContext>(options =>
    options.UseInMemoryDatabase("HospitalDb"));
builder.Services.AddScoped<AppointmentRepository>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<NationalRegistryService>();



//Add rule implementations
builder.Services.AddScoped<IRule,ReferralRule>();
builder.Services.AddScoped<IRule,InsuranceApprovalRule>();
builder.Services.AddScoped<IRule,AssignedGPRule>();
builder.Services.AddScoped<IRule,FinancialApprovalRule>();
builder.Services.AddScoped<IRule,CprValidationRule>();
builder.Services.AddScoped<IRule, UnknownDepartmentRule>();

builder.Services.AddSingleton<IRuleDictionary>(sp =>
    new RuleDictionary(
        new Dictionary<string, List<IRule>>(StringComparer.OrdinalIgnoreCase)
        {
            ["General Practice"] = new() { new AssignedGPRule() },
            ["Surgery"] = new() { new ReferralRule() },
            ["Radiology"] = new() { new ReferralRule(), new FinancialApprovalRule() },
            ["Physiotherapy"] = new() { new ReferralRule(), new InsuranceApprovalRule() },
            ["Cardiology"] = new() { new ReferralRule(), new FinancialApprovalRule(), new InsuranceApprovalRule() }

        }));

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.MapPost("/appointments", async (AppointmentRequest request, AppointmentService appointmentService) =>
{
    var result = await appointmentService.ScheduleAppointmentWithRules(
        request.Cpr, request.PatientName, request.AppointmentDate,
        request.Department, request.DoctorName);

    if (result)
        return Results.Ok("Appointment scheduled successfully.");
    else
        return Results.BadRequest("Failed to schedule the appointment.");
});

app.Run();

// Updated AppointmentRequest model
public record AppointmentRequest(string Cpr, string PatientName, DateTime AppointmentDate, string Department, string DoctorName);