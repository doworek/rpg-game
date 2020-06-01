# RPG game
This is an oldschool RPG game project for C# programming university course. The aim was to use some design patterns and OOP in a real life application. The basic code comes from: https://github.com/JakubChecinski/GameC. Important to note: it's still a work in progress!
Classes added by me:

1 )in "Monster":
- Wolf
- Dragon
- DragonEvolved

in "MonsterFactories":
- WolfFactory
- DragonFactory

2) in "Item":
- AncientSword
- MagicSword
- GoldenSword

in "ItemFactories":
- SwordFactory

3) in "Skills":
- FloodPotion
- MagicalPotion
- SuperStrengthPotion
- FloodPotionDecorator
- MagicalPotionDecorator
- SuperStrengthPotionDecorator

in "SkillFactories":
- BasicPotionFactory

4) in "Interactions":
- QuestInteraction
- MysteryBoxInteraction
- GnomeEncounter
- WhiteDragonEncounter
- QuestFactory
- IWhiteDragonStrategy
- WhiteDragonDefaultStrategy
- WhiteDragonNormalStrategy
- WhiteDragonAggressiveStrategy
- IPrincessStrategy
- PrincessEncounter
- PrincessDefaultStrategy
- PrincessNormalStrategy
- PrincessGratefulStrategy
- QuestBeginStrategy
- QuestCompleteStrategy

5) Index - added factories and items
