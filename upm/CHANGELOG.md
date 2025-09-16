# Changelog

All notable changes to this project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.1.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2025-09-15

### Added

- `RequireExtensions` class with `Require()` method for argument and state validation
- `Is` class for creating validation requirements with comprehensive type support:
  - Null checks (`Is.Null`, `Is.Not.Null`)
  - String validation (`Is.NullOrEmpty`, `Is.NullOrWhiteSpace`, `Is.EqualTo`)
  - Numeric validation (`Is.EqualTo`, `Is.InRange`, `Is.NaNf`, `Is.NaNd`)
  - Boolean validation (`Is.True`, `Is.False`)
  - Type validation (`Is.TypeOf<T>()`, `Is.AssignableTo<T>()`)
  - Collection validation (`Is.CollectionEmpty`)
- Inverted requirements support through `Is.Not` for opposite validations
- `RequireException` with detailed diagnostic information
