# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.1] - 2023-06-11

### Added

- There is now a transition between scenes, to make things much smoother.

### Changed

- Now uses Unity 6000 instead of Unity 2018. Finally.
- All instances of text have been changed to TextMeshPro, which makes it look much better.
- The project has been internally reorganized, removing unused assets, placing everything in their correct folders, and using proper naming.
- Splitscreen will now toggle based off of the players distance from each other instead of the camera FOV, as using camera FOV caused issues in Unity 6000.
- Materials have been improved to be slightly easier to see.
- Source code link in credits now links to [the new repository](https://github.com/snight-chesyon/Reflections).
- All UI now uses anchors, which should make it work properly on resolutions other than 1920x1080. Certain aspect ratios may still encounter issues, but 16:9 or any other reasonable horizontal aspect ratios should work fine.

### Fixed

- Players would treat their own door as valid ground, allowing the player to jump while inside of one. This was most notable with the platforms in level 5, where the player would fall much slower inside of them due to being considered grounded. The player will now properly fall through their doors.
- An issue would cause moving platforms to move twice as fast than the intended speed when a player was standing on them.
- Stars would not fade out. This was fixed by changing the shader to the legacy Alpha Blended shader.
- Star particles had transparency issues, causing a square to appear around them.
- Sounds were improperly balanced. In particular, the pressure plate sounds were too quiet, and the mirror passthrough sound used the wrong implementation.

## [1.0.0] - 2024-06-06

### Added

- The whole game so far.
