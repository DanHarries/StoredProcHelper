# Stored Proc Helper
A helper class to execute stored procs that don't have a return value more generically.  

You just have to ensure the params populate a ```Dictionary<string, object>()``` with a key, pair of the @param and value, then 
pass the name of the sp to the helper class, and it will take care of everything 😉.
