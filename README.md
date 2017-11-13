# Software Engineer Technical Development Challenge

This runs a windows based application that is a simple calculator. Once running, it will begin a series of calculations and close itself upon completion using WinAPI functions.

##### Here a few a things I would refactor if I was not concerned about completing this in a relatively timely manner, and would be happy to do so, if you prefer. 

##### Phase 1:
- Use of TryParse - If user inputs 0 or any other character that is not valid, this results in a message saying, "Cannot divide by 0."

##### Phase 2:
- Could use BackgroundWorker for thread in error messsage.
- Use of FindWindow not public, repeated myself a few times.