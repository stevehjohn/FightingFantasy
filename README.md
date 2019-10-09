# Fighting Fantasy

A nostalgic tribute to the old Fighting Fantasy books.

## TODO:

- Initial inventory.
- Only show some options based upon what's in the protagonist's inventory, or a default action if none of the items are available. See location 5 for e.g. Might need to alter description also.
- Battle. See locations 13, 22, 25, 28, 75 (just search for Antagonist in the json). Simultanious and one-at-a-time modes required?
- Using luck in battles.
- Test coverage.
- Mechanism to choose what inventory item to hand over. Location 22.
- Escape. Location 25.
- End state. See location 27.
- Pick up items. See location 33.
- Possesion based automatic moves. Location 34.
- Weird luck logic in location 39.
- Visit if not visited. Location 40.
- Increase initial Skill - 42.
- Knowledge - see Summon Sea Dragon in 47. Might be able to just make knowledge an item. See Item 9.
- Automatically pick up items. Location 54, black pearls. Also, take item when making a choice.
- How to handle the helpful dolphin name - location 61, 77.
- Automatic provision use - 66.
- Reduce number of enemies to fight based on provision use - 66.
- Reduced attack strength. 74.
- Automatic item pick up if you don't have one. 79.
- Lose random stamina points. See location 183.
- Temporary loss of points. See location 183.
- Maybe only make a choice available if user has an item, but don't make it default. This way, player can lie. See 67.
- Die if stamina == 0.
- Change IDs to strings? Then can have 81, 81a (restore luck) ordered to leave, 82a (restore stamina) ordered to leave, 162. This might work for the luck logic in 39 also.
- Auto take item when selecting a choice. 83.
- Auto obtain item when at a location. 84. 86.
- Use item at any time (except in battle) 84.
- Dice logic on 90.
- Item quantity logic. 100.
- Search for any TODOs...