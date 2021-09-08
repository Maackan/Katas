## Scheduler

Detta är ett program för att sköta handläggares 
scheman samt fördela sökande till lediga handläggare.

#### Tidshanteringen

Ett möte består av ett datetime då mötet börjar och ett
timespan för hur långt mötet varar.

1. Ställ i Meeting:s konstruktor att ett möte ska vara 
    30 min långt per default

I CaseWorkerVisualSchedule.RefreshDisplayedMeetings() så finns det
en for-loop som går igenom alla möten och representerar dem
i text. Vilken text som kommer per möte bestäms i Meeting.ToString()

2. Använd formatet `"H:mm"` för att lägga till från
    _när_ till _när_ ett möte ska ske i Meeting.ToString(). Använd addition för att lista ut när mötet slutar.
> ett möte klockan 8:00 som varar 30 min ska alltså se ut som `6/9/21 8:00 - 8:30`

### Felhanteringen

I C# kan ett problem uppstå i en del av koden för att sedan
hanteras i en senare del där man har möjlighet att göra något
åt saken. Ett problem som kan uppstå när man lägger till eller
bokar om möten är att ett valt möte kan överlappa med ett
redan existerande.

3. Använd `Meeting.Overlap()` metoden för att kolla i 
    `CaseWorker.NewDateAdded()` och `CaseWorker.ChangeMeeting()`
    om mötestiden överlappar med något existerande möte
    kasta i så fall undantaget `MeetingOverlapException`.
    Kör programmet och testa att undantaget sker om man försöker
    dubbelboka.

Om det inte gick att boka ett möte så är ingen skada skedd.
Men vi måste informera användaren att bokningen inte gick igenom
så att hen hänger med i vad som hänt och varför.

4. Inne i CaseWorkerVisualSchedule klassen, slå in anropen 
    `ChangeMeeting()` och `NewDateAdded()` i try-satser.
    Matcha på `MeetingOverlapException` i catch satsen och 
    använd `MessageBox.Show()` för att varna användaren om 
    vad som hänt. Testkör igen och se att varningsmeddelandet 
    dyker upp.

Tack vare throw/try systemet har vi nu kunnat säga att något
problematiskt uppstått i en del av programmet, och i en helt
annan del kunnat välja hur vi vill lösa situationen. På så sätt
behöver man inte tänka på GUI och felmeddelanden när man designar
möteslogiken.

### Slumphanteringen

För att detta företaget ska kunna jobba utan fördomar måste
fördelningen av ansökande fördelas slumpmässigt till handledare.

5. Förbättra situationen i `Scheduler.RandomlyFillUpMeetings()`
    genom att använda Random klassen. Slumpa ut en indexering 
    mellan 0 och antal oplacerade ansökande.

### Skicka runt instruktionslistor

Det hade varit fint att ha en siffra i `MainForm` som berättar 
hur många lediga möten som finns just nu. Problemet är att
det är UserController:n `CaseWorkerVisualSchedule` som håller koll på
när nya möten läggs till. Vi vet inte (i `MainForm`) _när_ siffran
behöver uppdateras.

Inne i MainForm så finns det en metod(`RefreshFreeSpotsLabel()`) som
beskriver _hur_ siffran ska uppdateras. Vi behöver bara få
varje `CaseWorkerVisualSchedule` att kalla på denna metoden när ett
nytt möte läggs till.

6. Ändra på konstruktorn i `CaseWorkerVisualSchedule` och lägg till
    en parameter `meetingAddedHandler` som är av typen `Action` (samma typ
    av metod som `RefreshFreeSpotsLabel()`). Skicka med 
    `RefreshFreeSpotsLabel` när du skapar `CaseWorkerVisualSchedule`
    objekten. Lägg en breakpoint i konstruktorn och kolla att metoden
    faktiskt kommit med.

7. Lägg till ett privat fält av typen `Action` där du sparar ner metoden
    som du skickar in till konstruktorn. Kalla sedan på den i `Button_Add_Click()`
    efter att ett nytt möte lagts till.

Nu signalerar vare `CaseWorkerVisualSchedule` GUI objekt när
något hänt i dess schema. `CaseWorkerVisualSchedule` tänker inte på
hur `MainForm` fungerar och `MainForm` ser allt det den behöver veta
via formen på `CaseWorkerVisualSchedule` konstruktorn!

### Sortering av listor

Det finns både namnlistor och möteslistor nu, så det hade varit lämpligt att hålla
dem sorterade.

8. Första steget är att skapa en metod som kan ta in och jämföra två `Applicant`:s
    genom att titta på deras namn.

9. Ta sedan och sortera `UnassignedApplicants` listan när den skapas och 
    när den töms, genom att kalla på `.Sort()` och skicka med metoden.

10. Gör nu en liknande metod, fast för att sortera `Meeting` objekt istället.
    De ska jämföras utifrån tiden möterna startar.

11. Hitta alla ställen där `Meetings` listan skapas/förändras, och se till att
    den efteråt sorteras med hjälp av metoden från punkt __10.__

Nu kommer mötena att hamna i kronologisk ordning även om ett möte senareläggs
eller ett tidigare möte läggs till! Bra jobbat!