# Provitöö

## Põhimõtted

### Liides

Disainimisel on kasutatud Veera disainisüsteemi (veera.eesti.ee), mida kasutatakse riiklike teenuste arendamisel.
Veera disainisüsteemi elemendid vastavad ligipääsetavuse standardi WCAG 2.2 nõuetele. Hetkel valminud prototüübis on osaliselt implementeeritud Veera disainisüsteemi. 

### Tesimine

Rakendusel on näidistestid, kuid kogu rakendust ei kata testid. Testitud on ainult mõned klassid igast kihist.

### Replikatsiooni logid
#### 4. Peab olema võimalik veenduda, et sõnum jõudis sõnumiruumi (näha ka sõnumi sisu):
 Valisin viisi sõnumilogide kinnitamiseks, kuulates loodud järjekorda ja sõnumeid sellest järjekorrast. Kui töötaja näeb sõnumit, otsib ta andmebaasist sõnumi päringu logi viite ID järgi ja uuendab seda sõnumist saadud sisuga. Sel viisil sisaldab sõnumilogi täpselt järjekorda saadetud sõnumit.

### Replikatsiooni süsteemid

Andmestruktuur toetab teadaolevate süsteemide, nende instantside ja instantsitüüpide, keelte laiendamist, kuid selle andmestiku haldamine ei kuulu projekti skoopi. Süsteemil on eelkonfigureeritud sihtrakendused koos nende instantsidega.

### Andmemudel 
Andmemudel on üsna lihtne. See kasutab surrogaate võtmeid koos naturaalse võtmega. Ressursse, millele pääsetakse väliselt ligi, kasutatakse naturaalse võtmega, kuid sisemised seosed luuakse surrogaatsõlme abil. See lahendus on valitud võimaldamaks pehme kustutamise tuleviku rakendamist.

## Projekti Struktuur

Projekt jaguneb mitmeks osaks:

1. **Backend API (`api`)**: REST API, mis on ehitatud .NET 8 abil. See sisaldab kontrollereid, teenuseid ja asutuste haldamiseks. 
3. **Frontend (`web-ui`)**: Veebi kasutaja liides mis kasutab REST api
4. **RabbitMQ (`mq`)**: Replikatsiooni vahend.
5. **Andmebaas (`db`)**:  andmebaas.
6. **Taustateenus(`worker`)**: Taustateenus, mis kinnitab sõnumi saatmis siis kui sõnum on nimeruumis ilmunud.

Projekt on konteineriseeritud, kasutades Docker Compose'i, mis võimaldab lihtsat seadistust ja juurutamist.


## Alustamine

### Rakenduse Käivitamine

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

3. **Juurdepääs rakendusele**:
   - **Veebi liides**: [http://localhost:4200](http://localhost:4200)
   - **REST Api**: [http://localhost:8080/swagger](http://localhost:8080/swagger)
   - **RabbitMQ admin liides**: [http://localhost:15672](http://localhost:15672)
   - **PostgreSQL**: `http://localhost:5432.

