# What you should to know...

## ...if you'd like to make own level:
* To make own level(s) you need to go to the Walker.Levels(); method and make new/change exist "map" massive. 
* Then add it into "case" condition in this method and change Walker.Gameplay(); in some places to "open" it(for example, change max. value of "current_map" variable in 951st string).

## ...if you'd like to make own element:
* Add it into "elems" massive and add own condition and function in Walker.Move(); method. Then we recommend to add an element into MapMaker(); as letter mention.
* If this is a thing, you need to add it into "things" massive and add:
   > thingTaken = true;
   > 
   > thing_type = <nocode><your element></nocode>
   into the function.

## ..if you'd like to make other:
* If you'd like to make own method, make it in the Walker class or in own class.
* If you'd like to change some text or anything else, change it =)
