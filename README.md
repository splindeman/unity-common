# Unity Common

Shared Unity utilities reused across [three-spin-gauntlet](https://github.com/splindeman/three-spin-gauntlet),
[hotel-honcho](https://github.com/splindeman/hotel-honcho), and future game projects, so genuinely
generic code (not game-specific logic) lives in one place instead of drifting between copies.

## Using this in a game project

Add it to the project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.splindeman.unity-common": "https://github.com/splindeman/unity-common.git",
    ...
  }
}
```

Unity's Package Manager will pull it in via git. To pin a specific version once this has tags,
append `#v0.1.0` (or similar) to the URL.

## What belongs here

Genuinely reusable, game-agnostic code: small utilities, extension methods, editor tooling,
base classes for common patterns (state machines, object pools, save/load). **Not** game design
or gameplay-specific systems — those belong in the individual game's own `Assets/`.

## Contents so far

- `Runtime/Singleton.cs` — generic `MonoBehaviour` singleton base class. Minimal starter; add to
  this as real reusable needs come up across projects rather than pre-building things speculatively.

## Versioning

Not yet using git tags for versions — every project currently points at `main`. Once this has
enough real usage across projects to make breaking changes a concern, switch to tagged releases
(`git tag v0.1.0`) and have each project's manifest pin a specific tag.
