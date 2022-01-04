# GrenadeThrowRangeFix
This mod fixes the calculation of the throw range of grenades.

## Description
The original method to calculate the throwing range doesn't take the defined ranges for hand thrown grenades into account.
This value is also shown to the player as 'Range' in the stats overview of grenades and is set to 16 for the PX Odin and Heal grenade and 12 for alomst any other.

The vanilla calculation is:

`(Endurance * EnduranceToThrowMultiplier) / GrenadeWeight * RangeMultiplier + BonusAttackRange`
- `Endurance` is the Strength of the actor
- `EnduranceToThrowMultiplier` is a fixed value for each actor and set to 0.6
- `GrenadeWeight` is from the grenades definition, all have a weight of 1
- `RangeMultiplier` is an input variable for the calculation function and comes from the ThrowGrenade_ShootAbilityDef.ProjectileRangeMultiplier, fixed set to 1.0
- `BonusAttackRange` is from abilities like Boom Blast (+50% range), so normally 0.0

This means that any grenade has always the same range regardless of its shown range value in the UI (12 tiles with 20 strength).

This mod changes the calculation to:

`(Endurance * EnduranceToThrowMultiplier * GrenadeRange / ThrowRangeDivisor) / GrenadeWeight * RangeMultiplier + BonusAttackRange`
- `GrenadeRange` is the value from the grenade definitions under DamagePayload.Range
- `ThrowRangeDivisor` is a configurable value, see "Config" tab in Modnix, default set to 12 what means that with 20 strength you get the throw range in tiles shown in the grenade stats.

This mod is mainly a helper for other modders that want to tweak the throwing range of the grenades in this game.
The vanilla ranges are 16 for the PX Odin and Heal grenade and 12 for almost any other grenade, so be aware that the Odin and Heal grenade get a significant buff with this mod from 12 up to 16 tiles range with 20 strength.

## Installation and Configuration
Download .7z, open Modnix 3+, click "Add Mod", select .7z, open "Config-Tab", configure, save, run game.

## Thanks
* As always: Sheepy, nothing would work this way without her Modnix, modding tutorial and other tools
* Nijuyin and IAmLoLed for pointing out that there is something wrong with the throw ranges of grenades
* Finally Snapshot Games for this nice game