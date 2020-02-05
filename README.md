# CodeGenerator

1. [Verwendung](#verwendung)
   1. [yEd-Notation](#yed)
      1.  [Static](#static)
      2.  [Abstract](#abstract)
2. [Test-Komponenten Beschreibungen](#test)
   1. Test: CodeGenerator](#test-codegenerator)
   2. Test: Controller](#test-controller)
   3. Test: Reader](#test-reader)
   4. Test: Generator](#test-generator)
3. [Authors](#authors)
4. [License](#license) 



Dieses Programm erstellt ".cs"-Dateien und füllt sie mit generiertem Quelltext, welcher auf der bereitgestellten ".graphml"-Datei beruht. 



## Verwendung <a name="verwendung"></a>

Nach dem Starten des Programms sollten zunächst, die fertige ".graphml"-Datei, als Quelle, und ein gewünschter lokaler Ausgabeort ausgewählt werden. Zu beachten ist, dass das Programm nur eine korrekte Form der ".graphml"-Datei akzeptiert.

### yEd-Notation <a name="yed"></a>

In yEd ist nur die Palette, der UML Elemente, gültig. Zudem sind auch nur zwei Elemente richtig realisierbar vom Programm,  Elemente: **"Klasse" **& **"Generalisierung"**. Für die Umsetzung des Klassen Diagramms gelten die Allgemeinen Notations Regeln für die UML-Klassendiagramme, nach der C#-Ordnung.

<img src="https://i.ibb.co/QNmTYdG/Bildschirmfoto-2020-02-05-um-21-42-00.png" alt="Palette" style="zoom:50%;" />



#### Static <a name ="static"></a>

Für die Erzeugung statischer Methoden oder Attribute ist folgende Notation in yEd notwendig: Nach dem *Access-Modifier (falls vorhanden)* ist das Zeichen **'*'** notwendig. 

*Beispiel (siehe Bild):*

<img src="https://i.ibb.co/wp8L2Hs/static-Method.png" alt="static-Method"  align="left" width="250" />

<br></br>





#### Abstract <a name ="abstract"></a>

Für eine Abstrakte Klasse ist folgende Notation in yEd notwendig: Unter der Einstellung *Beschriftung* ist der Schriftstil auf *kursiv* zu setzen.

​																																			*Beispiel (siehe Bild):*

<img src="https://i.ibb.co/c3s7jqh/abstract-class.png" alt="abstract-class" align="right" width="200" />

<br></br>





<br></br>

## Test-Komponenten Beschreibungen <a name ="test"></a>

### Test: CodeGenerator <a name ="test-codegenerator"></a>

Um das Projekt als Ganzes zu testen, ist die Komponente "CodeGenerator.GUI" auszuführen. Beispieldateien hierfür sind im Gitlab-Repository zu finden (Einfacher Test: "classdiagram.graphml", Komplexer Test: "completedDiagram.graphml").

### Test: Controller <a name ="test-controller"></a>

Die Testkomponente des Controllers "CodeGenerator.ControllerTest" kreiert den Ausgabepfad im Verzeichnis der Program-Klasse und den Dateipfad der (im Verzeichnis der Komponente abgespeicherten) "classdiagram.cs"-Datei. Mit übergabe dieser Pfade, ruft sie die Methode StartProcess auf, welche die Komponenten "CodeGenerator.Reader" und "CodeGenerator.Generator" erstellt und einen Datenaustausch simuliert. Dabei erhält der Controller, nach übergabe des Dateipfades, vom Reader ein Datamodel und gibt dieses, zusammen mit dem Ausgabepfad, dem Generator weiter. 

### Test: Reade <a name="test-reader"></a>

Die Reader-Komponente besitzt im ganzen zwei Test-Komponenten, und zwar einmal "CodeGenerator.ReaderTest" und "CodeGenerator.ReaderUnitTest". Dabei stellt das Projekt "CodeGenerator.ReaderTest" die Haupt-Testkomponente dar. Diese Komponente erzeugt lediglich ein valides Datenmodell aus einem Klassendiagramm, welche in Form einer .Graphml Datei vorliegt. Die Ergebnisse werden in einer Konsolen-Applikation dargestellt. Sinn und Zweck dieser Test-Komponente ist es, feststellen zu können ob ein Datenmodell erzeugt werden kann und ob sie für die weiter Verarbeitung eine korrekte Struktur annimmt.

Das Projekt "CodeGenerator.ReaderUnitTest" testet die Reader-Komponente auf spezielle Fälle. Aus einem Klassendiagramm werden Werte geladen und jeweilige Objekte erzeugt. Diese werden mit den korrekten Ergebnissen, die eigentlich aus dem Diagramm entnommen werden sollten, verglichen. 
Diese Unit-Test's können innerhalb des Visual-Studio Testexplorers ausgeführt werden.

### Test: Generator <a name ="test-generator"></a>

Das Projekt "CodeGenerator.GeneratorTest" testet die Generator-Komponente. Zu Beginn wird ein Dummy-DataModel mit Attributen, Methoden, Interfaces und Klassen erstellt. 
Dieses wird dem Generator übergeben, zusammen mit einem Ausgabepfad. 
Das Ausgabepfad ist standardmäßig der Ordner "GeneratorTestFiles", welcher auf dem Desktop des aktuellen Nutzers erstellt wird, sollte er bisher nicht existieren.



## Authors <a name ="authors"></a>

* **Emircan Yüksel** - GUI und Controller
* **Baris Tikir** - Reader
* **Yannik Sahl** - Generator und DataModel

## License <a name ="license"></a>

Dieses Projekt ist lizensiert unter der MIT-Lizenz.