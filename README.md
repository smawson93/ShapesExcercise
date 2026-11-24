The program runs currently in that it splits the text file into a string array.

From there it splits each line into the coordinates and depending on size if 3 or 4 will then do the checks for each if a valid rectangle or triangle.

If the line has that number of points I then split each point into their x / y coordinates and set up a try catch exception to catch anything that errored. 

For a triangle to determine that it is a valid triangle I calculated the area of the triangle to make sure it was not a straight line, if it was a straight line then it would return a 0 and note it invalid. 

For rectangles not much time was left to determine a correct way of reviewing this, I set it up for a valid rectangle either x or y from point 1 to 2 has to be the same and the other different and so on. 
The idea for this would be that if either point is a match and the other isn't then it can move on and using nested if statements made it so that it would move on to next one if it passed until all 4 points are check against the next when drawing the rectangle.

Current testing is using the console to write a line for each set of coordinates that notes whether it's a valid or invalid triangle/rectangle if coordinates passed and all others at the moment are noted to be an invalid shape.


How to improve:

My time spent on this excercise has stressed how I need to spend more time coming back up to speed with firstly the syntax and also how to write more effective code. 

I started each step within the main code and built on top of it per check but when it came to setting up unit testing because the checks were all in the main code line and not in seperate functions it meant that I could not set that up. 

Before I entered any data from the text file I should've built each shapechecker method first and applied unit testing as a starting point then built up from there. 

