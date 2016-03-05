# Puzzle Idea #2

## Introduction
In the Past player is in front of a brook, while in the Future player is in front of a two-way road with trees between the two directions.

The brook is generally very wide, but as one spot it is narrow. This spot can be reached by walking on the left lane of the Future.

The player needs to find something to put over the brook to go across.

There are 3 pieces of wooden boards in the Past.

* Board 1 is very long, enough to be put on anywhere along the brook to go across it. However, the location of Board 1 is not reachable in the Future.
* Board 2 is close to the brook, but is not long enough even for the narrow part of the brook.
* Board 3 is reachable through the right lane of the road in the Future, but is not long enough to go across the river there. It is long enough to be put on the left part of the brook.

## Objects in the Past

### Brook
* description: a brook that is almost straight, almost with the same width all along, except at the `narrow spot`
* children objects: `narrow spot`, `right part` 

#### narrow spot
* description: a narrow spot at the brook, a good place to put a wooden board at
* location: corresponding to `left lane` of `Two-way Road`

#### right part
* description: just a normal segment of the brook
* location: corresponding to `right lane` of `Two-way Road`

### Board1
* length: long, enough to be put over the brook
* location: relatively far from the river, not reachable in the Future
* attributes:
 - pickable 

### Board2
* length: short, not long enough to be put over the narrow spot of the brook
* location: close to `narrow spot`, corresponding to somewhere in the `left lane` of `Two-way Road`
* attributes:
 - pickable
* scripting:
 - when put at `narrow spot`: generates *Warning* dialog **OR** just floats away on the brook
 - when put at `right part`: generates *Warning* dialog **OR** just floats away on the brook

### Board3
* length: medium, long enough to be put over the narrow spot of the brook
* location: corresponding to somewhere in the `right lane` of `Two-way Road`
* attributes:
 - pickable
* scripting:
 - when put at `narrow spot`: generates *Notification* dialog **AND/OR** just stays over the brook
 - when put at `right part`: generates *Warning* dialog **AND/OR** just floats away on the brook

### Environmental Objects
* trees
* flowers
* grass
* paths

## Objects in the Future

### Two-way Road
* description: a two-way road with trees in between two directions
* children objects: `left lane`, `right lane`

#### left lane
* description: 
* location: corresponding to `narrow spot` of `Brook` and `Board2`

#### right lane
* description:
* location: corresponding to `right part` of `Brook` and `Board3`


### Environmental Objects
* trees
* flowers
* grass
* sidewalks

