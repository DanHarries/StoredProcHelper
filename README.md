# Stored Proc Helper
A helper class to execute stored procs more generically as I use a lot of sp's at work.  

You just have to ensure the params populate a ```Dictionary<string, object>()``` with a key, pair of the @param and value, then 
pass the name of the sp to the helper class, and it will take care of everything 😉.
