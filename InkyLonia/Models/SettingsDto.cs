using System.Collections.ObjectModel;
using LorcanaLogic;

namespace InkyLonia.Models;

public class SettingsDto
{
  public readonly int Revision = 1;
  public ObservableCollection<DeckPlaintext> DeckPlaintexts { get; set; } = [];
  public ObservableCollection<DeckPlaintext> ConstructedDeckPlaintexts { get; set; } = [];
}