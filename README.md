Prostredie
---------

Windows 64bit

Solution programu otvoríte pomocou Calculator.sln, ktorý sa nachádza v priečinku src/Calculator

Makefile sa nachádza v priečinku src\
Na buildnutie projektu: make build
Na vygenerovanie doxygen dokumentacie: make doc
Na spustenie TDD testov: make test
Na buildnutie standard deviation: make profile
Na spustenie aplikácie (najprv je nutné použiť make build): make run

Na nainštalovanie aplikácie je treba najprv buildnúť aplikáciu a potom otvoriť Setup.exe alebo Setup.msi, ktorý sa po buildnutí bude nachádzať v priečinku src/Setup/Release
Na odinštalovanie aplikácie sa môže použiť odinštalátor, ktorý sa po inštalácií (ak užívateľ nezmení defaultnú cestu) bude nachádzať v priečinku C:\Program Files(x86)\Memoryleak\Calculator, prípadne môže odinštalovať aplikáciu cez ovládací panel

Autori
------

Memory Leak
- xsluka00 Dušan Slúka 
- xduric06 Matúš Ďurica
- xmahut01 Ivan Mahút
- xpagan00 Gabriela Paganíková

Licence
-------

GNU GPL v.3
