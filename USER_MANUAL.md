# FloatWise — Complete User Manual & System Guide
**MoMo Agent Manager (Ghana Mobile Money Operations)**  
*Version 2.0 | Supported Networks: MTN MoMo, Telecel Cash, AT Money*

---

## Table of Contents
1. [System Overview & Architecture](#1-system-overview--architecture)
2. [Roles & Security Permission Matrix](#2-roles--security-permission-matrix)
3. [First-Time Setup & Account Initialization](#3-first-time-setup--account-initialization)
4. [User Interface & Tab Tour](#4-user-interface--tab-tour)
5. [Daily Shift Operations](#5-daily-shift-operations)
   - [Recording a Cash-In (Customer Deposit)](#recording-a-cash-in-customer-deposit)
   - [Recording a Cash-Out (Customer Withdrawal)](#recording-a-cash-out-customer-withdrawal)
   - [Recording a Float Top-up](#recording-a-float-top-up)
   - [Transaction Numbers & Phone Handling](#transaction-numbers--phone-handling)
6. [Cash Drawer Reconciliation (Physical Cash Tab)](#6-cash-drawer-reconciliation-physical-cash-tab)
7. [E-Cash Wallet Auditing (E-Cash Tab)](#7-e-cash-wallet-auditing-e-cash-tab)
8. [Administrator Control & Oversight](#8-administrator-control--oversight)
   - [Managing Worker Accounts](#managing-worker-accounts)
   - [Setting Float Low-Balance Limits](#setting-float-low-balance-limits)
   - [Setting Opening Balances](#setting-opening-balances)
   - [Voiding a Transaction](#voiding-a-transaction)
   - [Activity Audit Log](#activity-audit-log)
9. [Daily Reporting, Printing & Backups](#9-daily-reporting-printing--backups)
10. [Troubleshooting & Frequently Asked Questions](#10-troubleshooting--frequently-asked-questions)

---

## 1. System Overview & Architecture

FloatWise is a high-reliability Windows desktop application designed specifically for Ghanaian Mobile Money (MoMo) retail agents and multi-teller kiosks. FloatWise unifies three critical operational workflows into a single interface:
1. **Multi-Network Float Monitoring**: Live balances for MTN MoMo, Telecel Cash, and AT (AirtelTigo) Money.
2. **Physical Cash Till Balancing**: Denomination-by-denomination cash counting and variance tracking.
3. **Strict Role-Based Multi-User Separation**: Enterprise segregation between Owner/Admin supervisory duties and Teller/Worker operational shifts.

### Technical Specifications
- **Operating Environment**: Windows 10 / Windows 11 (64-bit & 32-bit compatible).
- **Runtime**: Microsoft .NET Framework 4.7.2.
- **Storage & Security**: Zero cloud dependency. High-performance local ledger with PBKDF2 cryptographic credential protection (`HMAC-SHA1`, 10,000 derivation rounds, per-user cryptographic salt).
- **Design Mode Support**: Visual Studio declarative Windows Forms Designer with full component serializability.

---

## 2. Roles & Security Permission Matrix

FloatWise enforces strict role segregation. **Admin transactions, configuration adjustments, and management logs never interfere with Worker shifts.**

| Feature / Capability | Worker (Teller) | Admin (Manager / Owner) |
|---|:---:|:---:|
| Dual Tab Login with Lockout Defense | Yes | Yes |
| Record Cash-In & Cash-Out | Yes | Yes |
| Record Float Top-Up | Yes | Yes |
| View Assigned Shift Transactions | Yes (Worker's Only) | Yes (All / Role Scoped) |
| View Customer Phone Numbers in Full | Yes | Yes |
| Real-Time Commission Calculation | Yes | Yes |
| Cash Denomination Counter | Yes | Yes |
| E-Cash SIM Phone Balance Check | Yes | Yes |
| Generate Shift / Daily Report | Yes (Worker's Scope) | Yes (All Combined Scope) |
| Print & Save Daily Report | Yes | Yes |
| Export Shift CSV Backup | Yes (Worker's Scope) | Yes (Full System Backup) |
| View Activity Audit Log | Restricted (Worker actions only) | Full (All System Actions) |
| Create & Toggle Worker Accounts | No (Tab Hidden) | Yes (Users Tab) |
| Set Telecom Low-Float Alert Limits | No (Button Hidden) | Yes |
| Set Opening Float & Till Balances | No (Button Hidden) | Yes |
| Void Transactions with Audit Reason | No (Button Hidden) | Yes |
| Match Till Balance to Cash Count | No (Button Hidden) | Yes |
| Delete or Clear Activity Logs | No (Buttons Hidden) | Yes |

---

## 3. First-Time Setup & Account Initialization

### Initial Run & Admin Creation
When launching FloatWise on a clean machine:
1. The system detects that no administrator exists.
2. The **First-time Admin Setup** link appears automatically at the bottom of the sign-in card.
3. Click **"First time? Create Admin account"** to open the registration screen:
   - **Full Name**: Enter the owner or manager's name (e.g. `Kwame Mensah`).
   - **Username**: Choose 3–20 alphanumeric characters (e.g. `admin`).
   - **Password**: Minimum 6 characters containing at least one letter and one number.
   - **Confirm Password**: Re-enter password.
4. Click **Create Admin Account**. Upon creation, FloatWise stores the salted cryptographic hash and immediately switches back to the sign-in screen.
5. The public sign-up link automatically disappears to prevent unauthorized administrative account creation.

### Dual Role Sign-In & Security Lockout
- **Admin Tab**: Purple theme. Used by supervisors to access user controls, limits, and system audits.
- **Worker Tab**: Teal theme. Used by daily shift tellers to record customer transactions.
- **Brute-Force Lockout Guard**: If 5 consecutive invalid passwords are submitted, the application locks login attempts for 30 seconds with a countdown timer.

---

## 4. User Interface & Tab Tour

### Header Banner
- **Left**: FloatWise brand logo and subtitle.
- **Right**: Active user name, colored role chip (**ADMIN** in purple, **WORKER** in teal), **Log Out** button, and safe **Exit** button.

### Dashboard (Tab 1 — Green Accent)
- **Top Metric Cards**:
  - **Cash in Till**: Physical paper cash currently in the register.
  - **MTN MoMo Float**: Available electronic float balance.
  - **Telecel Cash Float**: Available electronic float balance.
  - **AT Money Float**: Available electronic float balance.
- **Alert Banner**: Highlights in green when all floats are healthy, or warning amber when any float falls below its configured threshold.
- **Transaction Entry Group Box**: Ergonomic radio-button network selectors, transaction type selectors, customer phone input, amount field, quick-amount buttons, and live commission preview.
- **Transactions Grid**: Real-time list of transactions showing Time, Network, Type, Full Phone Number, Amount, Commission, and Recorded By.
- **Action Buttons**: Set Float Limit (Admin), Set Balances (Admin), Void (Admin), Daily Report, Save Backup.

### Physical Cash (Tab 2 — Amber Accent)
- **Cash Denomination Counter**: Input boxes for counting physical banknotes and coins:
  - Banknotes: GH₵ 200, GH₵ 100, GH₵ 50, GH₵ 20, GH₵ 10
  - Coins / Small Notes: GH₵ 5, GH₵ 2, GH₵ 1
- **Discrepancy Indicator**:
  - `MATCH` (Green): Physical count exactly matches system book value.
  - `OVER` (Amber): Drawer has more physical money than entered transactions record.
  - `SHORT` (Red): Drawer has less physical money than entered transactions record.
- **Cash Movement Summary**: Total Cash-In received, Total Cash-Out paid out, and Total Top-Up spent today.

### E-Cash (Tab 3 — Blue Accent)
- Dedicated rows for MTN MoMo, Telecel Cash, and AT Money.
- **SIM Phone Audit**: Compare electronic balance on the physical agent phone against the FloatWise ledger to identify unrecorded customer deposits or provider network errors.

### Activity Log (Tab 4 — Brown Accent)
- Immutable operational trail: Sign-ins, transaction creations, till count recordings, balance adjustments, void events, and backups.
- Workers only see operational logs; sensitive administrative adjustments are restricted to Admin view.

### Users Management (Tab 5 — Pink Accent, Admin Only)
- User table showing Full Name, Username, Role, Status (Active/Disabled), and Creation Date.
- Add New User form: Provision new Workers or auxiliary Admins.
- Enable / Disable Account toggle button.

---

## 5. Daily Shift Operations

### Recording a Cash-In (Customer Deposit)
*Customer gives physical cash to teller; teller sends e-float to customer's phone.*
1. Under **Network**, select the target provider using the radio button (`MTN MoMo`, `Telecel Cash`, or `AT Money`).
2. Under **Transaction Type**, select `Cash-In`.
3. In **Customer phone number**, enter the customer's 10-digit mobile number (e.g. `024 123 4567`). FloatWise automatically validates Ghanaian network prefixes and warns if a number appears ported to another carrier.
4. In **Amount (GH₵)**, type the amount or click a quick-amount button (`+10`, `+20`, `+50`, `+100`, `+200`, `+500`).
5. Observe the **Commission** preview (automatically calculated at 0.5%).
6. Click **Save Transaction** (or press `Enter`).
7. Confirm the prompt summary.
8. **Result**: Cash in Till increases by the amount; selected Network Float decreases by the amount.

### Recording a Cash-Out (Customer Withdrawal)
*Customer sends e-float to agent; teller pays physical cash to customer.*
1. Select the **Network** radio button.
2. Select the `Cash-Out` radio button.
3. Enter the customer's mobile number.
4. Enter the withdrawal amount.
5. Observe the commission preview (automatically calculated at 0.8%).
6. Click **Save Transaction**.
7. **Result**: Cash in Till decreases by the amount; selected Network Float increases by the amount.

### Recording a Float Top-up
*Agent purchases electronic float using physical cash from the till.*
1. Select the **Network** radio button.
2. Select the `Float Top-up` radio button (the phone number field disables automatically).
3. Enter the amount of float purchased.
4. Click **Save Transaction**.
5. **Result**: Selected Network Float increases; Cash in Till decreases.

### Transaction Numbers & Phone Handling
FloatWise displays customer mobile numbers **in full with zero asterisk masking (`0241234567`)** across all tables, reports, and search queries:
- **Why full numbers are essential**: MoMo agents need instant, verifiable phone numbers to reconcile disputes against telecom SMS confirmations and customer carrier alerts.
- **Built-in Security**: Instead of fragile client-side masking that harms operational audits, FloatWise implements **Role-Based Tenant Isolation**: Workers only see their assigned shift data, while Admin data and bulk account files remain protected.

---

## 6. Cash Drawer Reconciliation (Physical Cash Tab)

At the start and end of every shift:
1. Navigate to the **Physical Cash** tab.
2. Count every note and coin in the cash drawer.
3. Enter the quantities into the denomination boxes (`GH₵ 200`, `GH₵ 100`, `GH₵ 50`, etc.).
4. The **Counted Cash Total** calculates automatically in real time.
5. Click **Record Cash Count**.
6. Review the discrepancy box:
   - If `MATCH`: Drawer is balanced.
   - If `OVER (+GH₵ XX.XX)`: Teller collected money without recording a transaction.
   - If `SHORT (-GH₵ XX.XX)`: Cash was handed out without entry, or incorrect change was given.
7. *(Admin Only)*: If an unresolved difference exists, the Admin can click **Match Till to Count** to formally align the system register with an audit entry.

---

## 7. E-Cash Wallet Auditing (E-Cash Tab)

1. Navigate to the **E-Cash** tab.
2. Check the agent phone balance via USSD (e.g. `*170#` on MTN).
3. Type the live balance into the **Actual balance on phone** box.
4. Click **Check**:
   - FloatWise compares phone balance with internal ledger.
   - Any difference indicates an unrecorded transaction or a delayed telecom commission payment.
5. Click **Top up float** on any low wallet to immediately transfer focus to the Dashboard with pre-selected network and top-up mode.

---

## 8. Administrator Control & Oversight

### Managing Worker Accounts
1. Log in as an **Admin** and open the **Users** tab.
2. Fill out **Full name**, **Username**, **Password**, **Confirm password**, and select Role (`Worker` or `Admin`).
3. Click **Create User**.
4. To deactivate a worker who has ended their shift or left employment, select their row in the grid and click **Enable / Disable Account**. Disabled accounts are immediately barred from logging in.

### Setting Float Low-Balance Limits
1. On the **Dashboard**, click the desired Network radio button (`MTN MoMo`, `Telecel Cash`, or `AT Money`).
2. Click **Set Float Limit**.
3. Enter the minimum threshold (e.g. `2000` for GH₵ 2,000.00).
4. When available float drops below this number, the dashboard card highlights in amber and the Low Float Alert banner activates.

### Setting Opening Balances
1. Click **Set Balances** (Admin only).
2. Follow the 4 sequential prompts to input starting morning values:
   - Cash in Till
   - MTN MoMo float
   - Telecel Cash float
   - AT Money float
3. System logs the adjustment and refreshes all cards.

### Voiding a Transaction
1. If a transaction was recorded in error, select its row in the **Today's transactions** table.
2. Click **Void (Reverse)**.
3. Enter the mandatory reason for voiding (e.g. `Wrong network selected by teller`).
4. FloatWise automatically reverses the cash and float movements, removes the transaction from active accounting, and writes an immutable audit record.

---

## 9. Daily Reporting, Printing & Backups

### Generating the Daily Report
1. Click **Daily Report** on the Dashboard.
2. The report dynamically compiles:
   - Report metadata (Date, Time, Prepared By, User Role).
   - Operational Summary (Transaction Count, Total Volume, Net Commission).
   - Network Breakdown (Txns, Volume, Commission for MTN, Telecel, and AT).
   - Transaction Type Breakdown (Cash-In, Cash-Out, Top-Up).
   - Closing Balances (Physical Till, Counted Till, Differences, and E-Floats).
   - Itemized Transaction Ledger with Full Phone Numbers.
3. Click **Print Report** to send directly to any thermal POS receipt printer or standard A4 printer.
4. Click **Save Report** to archive a clean text file.

### CSV Data Backups
1. Click **Save Backup** on the Dashboard.
2. Select destination path.
3. FloatWise exports a structured UTF-8 CSV containing all transaction IDs, timestamps, networks, types, full phone numbers, amounts, commissions, and teller usernames.

---

## 10. Troubleshooting & Frequently Asked Questions

#### Q: The sign-in screen says "Too many wrong passwords. Wait 30 seconds."
**A**: Five incorrect password attempts were entered. The security throttle automatically releases after 30 seconds.

#### Q: Why can't the worker see the Users tab or Set Balances buttons?
**A**: By design, administrative features (User creation, Till adjustments, Float limit overrides, and Voids) are strictly segregated from worker roles to protect the business owner from unauthorized tampering.

#### Q: Why does a customer phone number alert appear when recording?
**A**: FloatWise inspects Ghana mobile prefixes (e.g. `024` = MTN, `020` = Telecel, `026` = AT). If a teller selects MTN MoMo but enters an `020` number, FloatWise warns that the number may belong to another network, while allowing the transaction to proceed if the number was ported.

#### Q: How can I run FloatWise on a new PC?
**A**: Copy `FloatWise.exe` to the computer. FloatWise is self-contained and portable; it requires only standard Windows .NET Framework 4.7.2.
