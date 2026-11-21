# FloatWise — Mobile Money Agent & Float Management System

[![Build Status](https://img.shields.io/badge/build-passing-brightgreen.svg)]()
[![Platform](https://img.shields.io/badge/platform-Windows%20Forms%20%7C%20.NET%20Framework%204.7.2-blue.svg)]()
[![Database](https://img.shields.io/badge/database-SQLite%20(WAL%20Mode)-orange.svg)]()
[![Security](https://img.shields.io/badge/security-PBKDF2--SHA1%20Salted-success.svg)]()

> **FloatWise** is an air-gapped, offline-first Windows desktop enterprise application designed specifically for Ghanaian Mobile Money (MoMo) retail agents and multi-teller kiosks. It provides unified multi-network float tracking (MTN MoMo, Telecel Cash, AT Money), physical till denomination reconciliation, strict role-based data isolation, and tamper-evident audit logging.

---

## 👥 Project Group Members & Index Numbers

| S/N | Full Name | Index Number | Role / Contribution |
| :-: | :--- | :-: | :--- |
| **1** | **Akayete Benedict** | `10334595` | Project Lead & Full-Stack Systems Engineering |
| **2** | **Joshua Tettey Dorkah** | `10333960` | Software Architecture & Windows Forms UI/UX |
| **3** | **Basah Benedict** | `10327072` | Database Design, SQLite Engine & ACID Transactions |
| **4** | **Kelvin Ansah Oyirifi** | `10333899` | Cryptographic Security & PBKDF2 Authentication |
| **5** | **Simon Kofi Asem** | `10322968` | Business Logic, Financial Invariants & Cash Top-ups |
| **6** | **Oscar Kormla Leysa** | `10316597` | Physical Cash Denomination & Till Reconciliation |
| **7** | **Donkor Francis** | `10334809` | E-Cash SIM Auditing & Multi-Tenant Role Isolation |
| **8** | **Samuel Salase Azigi Plahar** | `10330785` | Reporting Engine, CSV Exports & Atomic Backups |
| **9** | **Herbert Kofi Sam** | `10333967` | Quality Assurance, Verification & Documentation |

---

## 🚀 Key Functional Modules

### 1. Multi-Network Float Monitoring
- **Real-Time Digital Floats**: Unified tracking across **MTN Mobile Money**, **Telecel Cash**, and **AirtelTigo (AT) Money**.
- **Low-Balance Alerts**: Automated threshold detection warns tellers before a wallet breaches configured safety reserves.
- **Strict Overdraft Protection**: The engine enforces atomic financial invariants—preventing negative float or negative till balances.

### 2. Physical Cash Till & Denomination Balancing
- **Complete Ghana Cedi Counter**: Full denomination inputs for **GH₵ 200, 100, 50, 20, 10, 5, 2, 1 notes and 2, 1, 0.50, 0.20, 0.10, 0.05, 0.01 coins**.
- **Automated Variance Detection**: Calculates `Physical Counted Cash - System Expected Till = Variance`.
- **Immediate Discrepancy Auditing**: Instantly highlights shortages, overages, or perfect balances to prevent end-of-shift till bleeding.

### 3. Strict Multi-Tenant Role Scoping
- **Admin (Owner / Manager)**:
  - Global cross-teller transaction ledger.
  - User management (create tellers, reset passwords, activate/deactivate accounts).
  - Float limit adjustments and opening balance overrides.
  - Complete, unfilterable tamper-evident system audit logs.
  - Single-click atomic database snapshots (`.db`) and CSV data exports.
- **Worker (Teller)**:
  - Isolated shift view: Workers can **only view their own transactions and activity logs**.
  - Zero access to other tellers' data or administrative financial configurations.
  - Protected customer phone number visibility and automated commission computation.

### 4. Enterprise Offline Architecture & Security
- **Embedded SQLite in WAL Mode**: High-concurrency Write-Ahead Logging (`%AppData%\FloatWise\floatwise.db`) with zero external cloud dependencies.
- **PBKDF2 Password Hashing**: Cryptographic `HMAC-SHA1` key derivation with 10,000 iterations and distinct per-user cryptographic salts.
- **Visual Studio Designer Serializability**: Fully decoupled CodeDOM structure compatible with the native Visual Studio WinForms Designer.

---

## 🛠️ System Requirements & Build Instructions

### Prerequisites
- **Operating System**: Windows 10 or Windows 11 (64-bit / 32-bit).
- **Runtime**: Microsoft .NET Framework 4.7.2 or 4.8.
- **Development Tooling**: Visual Studio 2022 (v17+) with *.NET desktop development* workload, or MSBuild Current.

### Building from Source

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/akabrrown/Floatwise.git
   cd Floatwise
   ```

2. **Restore NuGet Packages & Build Solution**:
   Using Visual Studio Developer Command Prompt or PowerShell:
   ```powershell
   & "C:\Program Files\Microsoft Visual Studio\18\Professional\MSBuild\Current\Bin\MSBuild.exe" FloatWise.vbproj /t:Rebuild /p:Configuration=Release
   ```

3. **Run Application**:
   ```powershell
   .\bin\Release\FloatWise.exe
   ```

---

## 🎬 System Showcase Video

An end-to-end 3-minute video presentation with professional neural voice narration and synchronized subtitles is included in the project:

- **Local Video**: `FloatWise_Showcase_3Min.mp4` (1080p Full HD, ~3 minutes)
- **Interactive Web Player**: Open `video_showcase/index.html` in any web browser to jump between all 6 feature scenes with interactive timestamps and playback controls.

---

## 📖 Comprehensive Documentation

For complete operation manuals, step-by-step cashier guides, voiding workflows, and administrative playbooks, refer to:
- **[User Manual (Markdown)](USER_MANUAL.md)**
- **[User Manual (Word Document)](USER_MANUAL.docx)**

---

## 📄 License & Academic Integrity
Developed as an academic software engineering capstone project. All rights reserved by the project group members.
