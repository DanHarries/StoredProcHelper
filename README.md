# Stored Proc Helper
A helper class to execute stored procs.  

Currently this is just for executing an sp when you don't need a data set/ return values. 
You just have to ensure the params populate a ```Dictionary<string, object>()``` with a key, pair of the <param, value> (no need for the @), 
then pass the name of the sp to the helper class, and it will take care of everything 😉.

### Roadmap
- [ ] Implement method for when using a dataset to execute stored proc.
