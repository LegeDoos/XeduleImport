# XeduleImport

## IMPORTEER JE ROOSTER IN OUTLOOK

**Handleiding onder voorbehoud en op eigen risico.**

### Downloaden en toevoegen

1. Ga naar Teams, Team "ICT Academie", Files, General, mapje "ICSRoosterImport"
2. Selecteer het juiste blok en download jouw persoonlijke ICS bestand
3. Open Outlook en ga naar je agenda
4. Sleep het bestand van de download locatie naar je agenda
5. Je rooster staat in je agenda

### Verwijderen

1. Ga in Outlook naar je agenda
2. Type in de zoekbalk "Xedule"
3. Verwijder alle gevonden items met de categorie "Xedule"
4. Je rooster is verwijderd uit je agenda

### Updaten

1. Voer de bovenstaande stappen "Verwijderen" uit
2. Voer de bovenstaande stappen "Downloaden en toevoegen" uit
3. Je rooster is weer up-to-date

---

## TECHNISCHE HANDLEIDING

### Project Overzicht

XeduleImport is een .NET 9 Windows Forms applicatie die Xedule roosters kan ophalen via de API en converteren naar ICS bestanden voor import in Outlook. Het project gebruikt de Ical.Net library voor het genereren van ICS bestanden.

### Technische Specificaties

- **Framework**: .NET 9.0 Windows
- **Applicatie Type**: Windows Forms (WinExe)
- **Dependencies**: 
  - Ical.Net (v5.1.0) - Voor ICS bestand generatie
- **Versie**: 0.0.0.3

### Project Structuur

```
XeduleImportHelper/
├── Program.cs              # Entry point van de applicatie
├── Business/               # Business logic layer
│   ├── Person.cs          # Person model
│   ├── Settings.cs        # Applicatie instellingen
│   ├── Teacher.cs         # Teacher model  
│   ├── Teachers.cs        # Teachers collection
│   ├── UpdateICSFileHelper.cs  # ICS bestand verwerking
│   └── XeduleAPIHelper.cs # Xedule API communicatie
└── UI/                    # User Interface layer
    ├── FormMain.cs        # Hoofd formulier
    ├── FormMain.Designer.cs
    └── FormMain.resx
```

### Ontwikkeling

#### Vereisten

- Visual Studio 2022 of hoger
- .NET 9.0 SDK
- Windows OS (vanwege Windows Forms)

#### Project Opzetten

1. Clone de repository
2. Open `XeduleImportHelper.sln` in Visual Studio
3. Restore NuGet packages
4. Build en run het project

#### Configuratie

De applicatie slaat instellingen op in: `C:\RCData\_XeduleHelper`

Configureerbare instellingen:
- Bearer Token voor Xedule API authenticatie
- Werkmap voor tijdelijke bestanden
- Bestemmingsmap voor gegenereerde ICS bestanden
- Datum bereik voor rooster export

#### API Integratie

De applicatie communiceert met de Xedule API:
- **Base URL**: `https://zuyd.myx.nl/api/`
- **Endpoints**:
  - `InternetCalendar` - Voor rooster data
  - `Attendee/Type/Teacher` - Voor docent informatie
- **Authenticatie**: Bearer token vereist

#### Build Process

Het project ondersteunt meerdere target frameworks:
- `net6.0-windows` (legacy)
- `net9.0-windows` (current)

Build outputs worden gegenereerd in `bin/Debug/` of `bin/Release/`

### Deployment

De applicatie is een standalone executable die kan worden gedistribueerd via:
- Direct executable (.exe) bestand
- MSI installer (indien geconfigureerd)
- ClickOnce deployment (indien geconfigureerd)


