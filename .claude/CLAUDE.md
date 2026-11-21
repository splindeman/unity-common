# unity-common

Shared Unity package `com.gamedev.unity-common` (Unity 6000.5). **Public repo: no secrets and no game-specific code or IP.** Workspace conventions are in `D:\Dev\CLAUDE.md`. Currently used by `hotel-honcho`.

- **What belongs here:** generic, game-agnostic code that two or more games need (utilities, extension methods, small containers). Game design and gameplay logic stay in each game's `Assets/`. Code that needs a package beyond `UnityEngine` (for example the Input System) stays in the game until the package is a dependency here.
- **Every file needs a committed `.meta`.** Consumers pull this by git URL, which Unity treats as immutable, so a missing `.meta` makes Unity silently ignore the asset. Generate them in a throwaway local Unity project (see `D:\Dev\dev-tools\NOTES.md`), never with hand-written GUIDs. This file lives in `.claude/` because Unity ignores hidden folders and would warn about a root file without a `.meta`.
- **Versioning:** consumers point at `main` for now. Tag releases (`v0.1.0`) and have consumers pin them before making any breaking change.
- **After pushing a change,** a consumer may keep resolving the old package from its cache: see "Unity git-package staleness" in `D:\Dev\dev-tools\NOTES.md`.
