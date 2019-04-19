Table of Contents
====================

Application Takes Input
---------------------
-   See RPSFight project > MainPage.xaml. Lines: 69, 71, 73, 75, 82, 84, 86, 88, etc.
-   See RPSFight project > ViewModels > MainViewModel.cs. The xaml code is bound to properties in our ViewModel to perform actions on the inputs.

Application Shows Output
---------------------
-   See RPSFight project > MainPage.xaml. Lines: 54-57, 158-161, 181, 191, 204, 205

Stores Values in Database
---------------------
-   See RPSFight project > ViewModels > MainViewModel.cs. Lines: 214-313
-   See RPSDataStorage > Data > DataStoreRepo.cs
-   See RPSDataStorage > Data > IDbRepo.cs
-   See RPSDataStorage > SqliteDataStore.cs

Log Operations
---------------------
-   See RPSFight project > ViewModels > MainViewModel.cs. Lines: 208, 223, 251, 272, 302

Perform Operations/Calculations/Rules
---------------------
-   See RPSBackendLogic > Entities > GameBoard.cs
-   See RPSBackendLogic > ValueObjects > Quantity.cs
-   See RPSBackendLogic > ValueObjects > Sentence.cs
-   See RPSBackendLogic > ValueObjects > Name.cs

Aggregate
---------------------

-   See RPSBackendLogic > Entities > GameBoard.cs

Entities
---------------------

-   See RPSBackendLogic > Entities

Value Objects / Domain Primitives
---------------------

-   See RPSBackendLogic > ValueObjects
-   See RPSBackendLogic > DomainPrimitives

Logging
---------------------

-   See RPSBackendLogic > Entities > GameBoard.cs
-   See RPSFight project > ViewModels > MainViewModel.cs
-   Click Show Log in application (for convenience).

5 Levels of Validation
---------------------

-   See RPSBackendLogic > ValueObjects > Name.cs
-   See RPSBackendLogic > ValueObjects > Sentence.cs
-   See RPSBackendLogic > ValueObjects > Quantity.cs
-   See RPSFight project > MainPage.xaml. (XAML Entry allows text input even when bound to an integer type and automatically assigns a 0 to it.)

Read-once Objects
---------------------

-   See RPSBackendLogic > DomainPrimitives > ModifierSet.cs

Failures vs. Exceptions
---------------------

-   See RPSFight project > ViewModels > MainViewModel.cs. Lines
-   See RPSBackendLogic > Entities > GameBoard.cs. Lines

Optional 1 Extra -> Entity Snapshots
---------------------
-   See RPSBackendLogic > Entities > Roshambo.cs.