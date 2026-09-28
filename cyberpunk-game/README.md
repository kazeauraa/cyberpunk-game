# 🎮 CyberpunkGame

![Version](https://img.shields.io/badge/version-1.0.0-blue.svg)
![Unity](https://img.shields.io/badge/Unity-6000.4.4f1-000000.svg?style=flat&logo=unity)
![C#](https://img.shields.io/badge/C%23-239120.svg?style=flat&logo=c-sharp)
![URP](https://img.shields.io/badge/URP-Universal_Render_Pipeline-43B02A.svg?style=flat)
![Platform](https://img.shields.io/badge/Platform-Windows%20%7C%20Android-lightgrey.svg)

**CyberpunkGame** to dynamiczna gra 2D osadzona w futurystycznym, neonowym świecie cyberpunku. Projekt został stworzony przy użyciu silnika Unity (z wykorzystaniem nowoczesnego potoku renderowania URP). Gra oferuje wciągającą rozgrywkę, zaawansowane oświetlenie i płynne sterowanie.

⚠️ **GOTOWA GRA:** W folderze **`Build`** znajduje się plik z gotową, skompilowaną wersją gry. Możesz ją stamtąd pobrać i zagrać od razu, bez konieczności instalowania silnika czy kompilacji projektu!

---

## ✨ Główne możliwości

### 🛠 Funkcjonalność rozgrywki
* **Ręcznie projektowane poziomy:** Kampania składająca się z wielu scen (Menu, Level 1 - 5) zbudowanych przy użyciu systemu Tilemap (`CityGround`).
* **Nowoczesne sterowanie:** Płynna obsługa klawiatury, myszy oraz kontrolerów (Gamepad) dzięki Unity New Input System.
* **Rozszerzona kamera:** Dynamiczne śledzenie gracza i efekty wstrząsów ekranu realizowane za pomocą pakietu **Cinemachine**.
* **Efekty wizualne (Post-Processing):** Zaawansowane efekty świetlne, bloom i neony charakterystyczne dla klimatu cyberpunkowego (oparte na URP).
* **Fizyka 2D:** Zoptymalizowane kolizje, system skoków oraz interakcje z przeciwnikami i pociskami (`Rigidbody2D`, `Collider2D`).

### 🎨 UI/UX (Interfejs)
* **Wysokiej jakości teksty:** Wyraźny, skalowalny i czytelny interfejs użytkownika zrealizowany za pomocą pakietu **TextMesh Pro**.
* **Dynamiczne menu:** Przejrzyste menu główne z łatwym przełączaniem poziomów.

---

## 🏗 Stos technologiczny (Tech Stack)

* **Silnik:** [Unity 6000.4.4f1](https://unity.com/)
* **Język programowania:** C#
* **Renderowanie:** Universal Render Pipeline (URP) dla grafiki 2D
* **Animacje i Grafika:** Wbudowane pakiety `2D Animation`, `2D Sprite`, `2D Tilemap`
* **Kamery:** Pakiet `Cinemachine` (wersja 3.x)
* **Zarządzanie wejściem:** `Input System` (zastępujący starszy system Unity)

---

## 🚀 Instalacja i uruchomienie

### 🎮 Dla graczy (Szybki start)
Nie musisz instalować żadnych narzędzi deweloperskich, aby zagrać w grę.
1. Pobierz repozytorium na swój dysk.
2. Wejdź do folderu **`Build`**.
3. Uruchom plik wykonywalny gry (.exe dla Windows lub .apk dla Androida) i ciesz się rozgrywką!

### 💻 Dla deweloperów (Uruchomienie projektu)
Aby otworzyć i edytować projekt, będziesz potrzebować [Unity Hub](https://unity.com/download) oraz edytora w wersji **6000.4.4f1**.

1.  **Sklonuj repozytorium:**
    ```bash
    git clone <tutaj_wstaw_link_do_repo>
    cd CyberpunkGame
    ```

2.  **Otwórz projekt:**
    * Uruchom **Unity Hub**.
    * Wybierz **Add** (lub Open) i wskaż folder z pobranym projektem.
    * Upewnij się, że używasz odpowiedniej wersji edytora. Jeśli Unity poprosi o aktualizację pakietów (np. w oknie Package Manager), zatwierdź ją.

3.  **Uruchom grę w edytorze:**
    * Przejdź do folderu `Assets/Scenes/`.
    * Otwórz scenę `Menu.unity` lub `Level 1.unity`.
    * Naciśnij przycisk **Play** na górnym pasku.

---

## 📂 Struktura projektu

Główne pliki projektu znajdują się w folderze `Assets`:

```text
/
├── Build/             # 🎮 SKOMPILOWANA, GOTOWA GRA DO URUCHOMIENIA
├── Assets/
│   ├── Animations/    # Kontrolery i klipy animacji (gracz, wrogowie)
│   ├── Audios/        # Efekty dźwiękowe i ścieżka dźwiękowa
│   ├── InputActions/  # Pliki konfiguracyjne dla New Input System
│   ├── Prefabs/       # Gotowe obiekty gry (Player, Enemy, Bullets itp.)
│   ├── Scenes/        # Sceny gry (Menu, Level 1 - 5)
│   ├── Scripts/       # Logika gry napisana w języku C#
│   ├── Settings/      # Pliki konfiguracyjne URP i innych systemów
│   ├── Sprites/       # Zbiór grafik 2D (postacie, tła)
│   ├── TextMesh Pro/  # Ustawienia i fonty interfejsu (UI)
│   └── Tiles/         # Assety do budowania poziomów (np. CityGround)
├── Packages/          # Zależności i pakiety Unity (manifest.json)
└── ProjectSettings/   # Globalne ustawienia projektu silnika Unity
