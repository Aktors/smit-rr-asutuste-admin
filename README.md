# Proovitöö

## Põhimõtted

### Liides

Valminud prototüübi disainimisel on osaliselt kasutatud Veera disainisüsteemi (veera.eesti.ee), mida kasutatakse riiklike teenuste arendamisel.
Veera disainisüsteemi elemendid vastavad ligipääsetavuse standardi WCAG 2.2 nõuetele.

### Testimine

Rakendusele on loodud 6 näidistesti. Igast kihist on testitud mõned klassid.

### Replikatsiooni logid
#### 4. Peab olema võimalik veenduda, et sõnum jõudis sõnumiruumi (näha ka sõnumi sisu):
 Nimeruumi sõnumi kinnitamiseks on kasutatud teavitused mida "worker" programm saab nimeruumidest. Sõnumi kohalejõudmisel otsib lahendus andmebaasist vastava sõnumi viite järgi ja taidab saadetud sõnumi logi sisu saadud sõnumi sisuga. Nii saab veenduda, et sõnum oli jõudnud nimeruumi ja logides on näha just seda andmestikku (kuju) mida oli saadetud. Kasutaja liidesest saab sõnumi logi tabelist näha ka sõnumi sisu JSON kujul. 

### Replikatsiooni süsteemid

Andmestruktuur toetab teadaolevate süsteemide, nende instantside ja instantsitüüpide, keelte loetelu laiendamist, kuid selle andmestiku haldamine ei kuulu projekti skoopi. Süsteemil on eelkonfigureeritud sihtrakendused koos nende instantsidega.

### Andmemudel 

Andmemudel on üsna lihtne. See kasutab surrogaatvõtmeid koos naturaalse võtmetega. Ressursse, millele pääsetakse väliselt ligi, kasutatakse naturaalse võtmega, kuid sisemised seosed luuakse surrogaatvõtme abil. See lahendus on valitud võimaldamaks soft-delete kustutamise rakendamist tulevikus.

## Projekti Struktuur

Projekt jaguneb mitmeks osaks:

1. **Backend API (`api`)**: REST API, mis on ehitatud .NET 8 abil. See sisaldab kontrollereid ja teenuseid asutuste haldamiseks. 
3. **Frontend (`web-ui`)**: Veebi kasutaja liides, mis kasutab REST api-d.
4. **RabbitMQ (`mq`)**: Replikatsiooni vahend.
5. **Andmebaas (`db`)**:  andmebaas.
6. **Taustateenus(`worker`)**: Taustateenus, mis kinnitab sõnumi saatmise siis kui sõnum on nimeruumis ilmunud.

Projekt on Docker konteinerites, kasutades docker-compose'i, mis võimaldab lihtsat seadistust ja juurutamist.


## Alustamine

### Rakenduse käivitamine

1. **Klooni repositoorium**:
   ```sh
   git clone <repository-url>
   cd <repository-directory>
   ```

2. **Käivita Docker Compose abil**:
   ```sh
   docker-compose up --build
   ```
   See koostab ja käivitab kõik vajalikud teenused (`api`, `web-ui`, `mq`, `db`, `worker`).

   Veendu, et kõik konteinerid on käivitanud. Esimese käivitamise puhul võivad konteinerid sõtuvuse pärast peatuda, kui sõltuv moodul ei jõudnud kõike asju initsialiseeruda (heartbeat jäi lihtsamal tasemel realiseeritud mida ei ole piisavalt). 

3. **Juurdepääs rakendusele**:
   - **Veebi liides**: [http://localhost:4200](http://localhost:4200)
   - **REST Api**: [http://localhost:8080/swagger](http://localhost:8080/swagger)
   - **RabbitMQ admin liides**: [http://localhost:15672](http://localhost:15672)
   - **PostgreSQL**: `http://localhost:5432.

