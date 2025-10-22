To solve this case, I decided to move the rules out to their own objects, meaning each rule is responsible for its own validiation.
To keep the overall core logic the same, I use interfaces to extend the design of the system and allow us to inject services when needed.
The system is kept flexible by using a Dictionary (rulesForDepartments in RuleDictionary) of departments and rules for each department. This allows us to search for a given department when we need to check for validation. 
If we need to add new vaildation checks, we simply have to create a new rule object. If we need to add a new department, we update the RuleDictionary and add the new department with any needed checks. 

A small rewritten version of ScheduleAppointment called ScheduleAppointmentWithRules was written in the AppointmentService file. 
