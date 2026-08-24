# Unity Common

Shared Unity utilities reused across [three-spin-gauntlet](https://github.com/splindeman/three-spin-gauntlet),
[hotel-honcho](https://github.com/splindeman/hotel-honcho), and future game projects, so genuinely
generic code (not game-specific logic) lives in one place instead of drifting between copies.

## Using this in a game project

Add it to the project's `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.gamedev.unity-common": "https://github.com/splindeman/unity-common.git",
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

- `Runtime/Singleton.cs` — generic `MonoBehaviour` singleton base class.
- `Runtime/Grid2D.cs` — fixed-size 2D grid container (game-agnostic), indexed by (col, row),
  with orthogonal-neighbor lookup.
- `Runtime/GridFloodFill.cs` — breadth-first connected-region search over a `Grid2D<T>`, given a
  predicate for which cells to include. Extracted from Hotel Honcho's chain-detection logic
  since it's genuinely generic (any tile-matching/flood-fill need, not just hotel chains).

Add to this as real reusable needs come up across projects rather than pre-building things
speculatively.

## Note on .meta files

Every file here needs a committed `.meta` file, unlike a normal Unity project's own `Assets/`
folder. This package gets pulled into other projects via git URL, which Unity treats as an
**immutable** source — it can only auto-generate missing `.meta` files for *mutable* locations.
For an immutable package, a missing `.meta` file means Unity silently ignores that asset
entirely (logged as `Asset ... has no meta file, but it's in an immutable folder`). See
`D:\Dev\tools\NOTES.md` for how to generate correct ones (a throwaway local Unity project, not
hand-authored GUIDs) when adding new files here.

## Versioning

Not yet using git tags for versions — every project currently points at `main`. Once this has
enough real usage across projects to make breaking changes a concern, switch to tagged releases
(`git tag v0.1.0`) and have each project's manifest pin a specific tag.
