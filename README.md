# Witch Escape 🧙‍♀️🏃‍♀️

A spooky adventure about a brave little girl!

## The Story

One day, a little girl was captured by a witch and locked in an old house. The witch says she's going out and warns: **"Don't you dare leave!"** Then she leaves.

The girl is scared... but she's brave! She gets up and tries the front door — it's locked! She needs clues to find the key.

She searches the old house and finds **5 clues** — then the key appears! She unlocks the door and runs out...

But the witch sees her! **"How dare you leave! I'm going to catch you!"**

Now the girl must run and **follow the glowing lights** all the way home!

## How to Play

1. **Search** the old house (walk to furniture, press E or tap) to find all 5 clues
2. **Grab the key** and unlock the front door
3. **RUN!** The witch chases you!
4. **Follow the glowing lights** one by one until you reach home

## Unity Setup

1. Build the old house scene with furniture that has the `Clue.cs` script (5 total)
2. Add `BraveGirl.cs` to the girl, `WitchChase.cs` to the witch (starts hidden)
3. Add `GlowTrail.cs` with glowing lights in order from the house to home
4. When the key unlocks the door, call `WitchChase.StartChase()`

Good luck, brave girl! 🏠✨
