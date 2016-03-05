# Puzzle Idea #1

## Introduction
In the Past player is in front of a huge gate/rock, while in the Future player is in front of an area guarded by some sort of security device, which scans the area to detect intruders.

The huge gate/rock can be opened by pull a lever at a spot not far yet not too close to the gate/rock. Then it will start to close again slowly.

It is not difficult for the player in the Future to pass this area without being detected by the security device if the player in the Past is not blocked by the huge gate/rock.

## Objects in the Past

### Huge Gate/rock
* description: a huge gate/rock that is in the player's way, canbe opend by pullling `Lever`
* scripting:
 - when `Lever` is pulled: firstly opens, then closes slowly

### Lever
* description: a lever that opens `Huge Gate/rock`
* attributes:
 - interactable

### Environmental Objects
* mountains
* trees
* flowers
* grass
* paths

## Objects in the Future

### Security Device
* description: a device that is monitoring the area by scanning for intruders
* scripting:
 - always: scanning the room for intruders
 - when detecting player: generates *Losing* dialog **AND/OR** kill player

### Environmental Objects

#### if outside
* streets
* sidewalks
* buildings/walls

#### if inside
* corridor/room
