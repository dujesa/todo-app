using TodoApp.Presentation.Extensions;
using TodoApp.Presentation.Factories;

var mainMenuActions = MainMenuFactory.CreateActions();
mainMenuActions.PrintActionsAndOpen();