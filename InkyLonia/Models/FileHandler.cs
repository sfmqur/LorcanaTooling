using System;
using System.Collections.ObjectModel;
using System.IO;
using LorcanaLogic;
using Newtonsoft.Json;

namespace InkyLonia.Models;

public class FileHandler
{
  private string _dataFolder;

  public FileHandler(string dataFolder)
  {
    _dataFolder = dataFolder;
  }

  public void SaveSettings(ObservableCollection<DeckPlaintext> constructedDecks,
    ObservableCollection<DeckPlaintext> decks)
  {
    var dto = new SettingsDto()
    {
      DeckPlaintexts = decks,
      ConstructedDeckPlaintexts = constructedDecks
    };
    try
    {
      var json = JsonConvert.SerializeObject(dto, Formatting.Indented);
      File.WriteAllTextAsync(_dataFolder+ @"\settings.json", json);
    }
    catch (Exception)
    {
      
    }
  }

  public SettingsDto LoadSettings()
  {
    var dto = new SettingsDto();
    try
    {
      using var fs = File.OpenText(_dataFolder + @"\settings.json");
      var json = fs.ReadToEnd();
      dto = JsonConvert.DeserializeObject<SettingsDto> (json) ?? dto;
    }
    catch (Exception)
    {
      if (File.Exists(_dataFolder + @"\settings.json"))
      {
        var name = _dataFolder + @"\settings.json";
        var dateTime = DateTime.Now.ToFileTime();
        File.Copy(name, _dataFolder + $"\\settingsBak_{dateTime}.json");
      }
    }
    return dto;
  }
}