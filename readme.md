Table of Contents
====================

Application Takes Input
---------------------
-   See RPSFight > MainPage.xaml. Lines: 69, 71, 73, 75, 82, 84, 86, 88, etc.
-   See RPSFight > ViewModels > MainViewModel.cs. The xaml code is bound to properties in our ViewModel to perform actions on the inputs.

Application Shows Output
---------------------
-   See RPSFight > MainPage.xaml. Lines: 54-57, 158-161, 179, 189, 202, 203

Stores Values in Database
---------------------
-   See RPSFight > ViewModels > MainViewModel.cs. Lines: 214-313
-   See RPSBackendLogic > Data > IDataStoreRepo.cs
-   See RPSBackendLogic > Data > IRepoService.cs
-   See RPSDataStorage > Data > IDbRepo.cs
-   See RPSDataStorage > DataStoreRepo.cs
-   See RPSDataStorage > SqliteDataStore.cs

Log Operations
---------------------
-   See RPSFight > ViewModels > MainViewModel.cs. Lines: 208, 223, 251, 272, 302

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
-   See RPSFight > ViewModels > MainViewModel.cs
-   Click Show Log in application (for convenience). Click again to show updated log.

5 Levels of Validation
---------------------

-   See RPSBackendLogic > ValueObjects > Name.cs
-   See RPSBackendLogic > ValueObjects > Sentence.cs
-   See RPSBackendLogic > ValueObjects > Quantity.cs
-   See RPSFight > MainPage.xaml. (XAML Entry allows text input even when bound to an integer type and automatically assigns a 0 to it.)
-   Origin Validation has been considered, but not necessary for the scope of this application. This is because the application is local with a local database and doesn't interact with network structures.

Read-once Objects
---------------------

-   See RPSBackendLogic > DomainPrimitives > ModifierSet.cs

Failures vs. Exceptions
---------------------

-   See RPSFight > ViewModels > MainViewModel.cs. Lines: 232, 234, 239, 264, 284, 298, 295, 315, 357, 362, 367
-   See RPSBackendLogic > Entities > GameBoard.cs. Lines: 90
-   See RPSBackendLogic > Exceptions

Optional 1 Extra -> Entity Snapshots
---------------------
-   See RPSBackendLogic > Entities > Roshambo.cs.