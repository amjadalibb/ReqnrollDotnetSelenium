# Advantage Shopping - UI Test Automation Framework

This repository contains the UI test automation framework developed for the **Advantage Shopping** website.

## 💡 Overview

- Developed in **C# .NET**, using **Selenium** and **NUnit**.
- Follows the **Behavior-Driven Development (BDD)** approach using **Reqnroll** (successor of SpecFlow).
- Implements the **Page Object Model (POM)** design pattern for maintainability and scalability.
- Utilizes **ExtentReports** for generating detailed test execution reports.
- Includes **error scenarios** from the **Create Account (Register)** page as example test cases.

---

## 🛠️ Setup Instructions

Follow the steps below to set up and run the framework locally:

1. **Clone the repository**
   
   ```git clone https://github.com/amjadalibb/ReqnrollDotnetSelenium.git```
2. **Install Visual Studio 2022 Community Edition**

   * Download from: [https://visualstudio.microsoft.com/vs/community/](https://visualstudio.microsoft.com/vs/community/)
   * Ensure you include the **ASP .NET Development** during installation.

3. **Install Dependencies**

   * Open the project in Visual Studio.
   * Restore NuGet packages via:

     ```dotnet restore```

4. **Build the Project**

   * Press `Ctrl + Shift + B` or use the **Build** menu.

5. **Open Test Explorer**

   * Go to `Test > Test Explorer` in Visual Studio.

6. **Run the Test Suite**

   * Click **Run All Tests** in the Test Explorer.

7. **View the Test Report**

   * Navigate to the `Reports\HtmlReport` directory.
   * Open the generated `.html` file to view the **Extent Report**.
     <img width="670" height="349" alt="image" src="https://github.com/user-attachments/assets/288a95be-e885-413e-96bf-e2d32e5fe066" />

---

## 📁 Project Structure (Overview)

```
📂 Config/                → Contains configuration file (e.g., base URL, browser details)
📂 Features/              → Gherkin feature files
📂 Helper/                → Helper methods for Selenium web elements
📂 Pages/                 → Page Object Model classes
📂 Reports/               → Output folder for ExtentReports
📂 StepDefinitions/       → Step definitions for BDD tests
```

---

## ✅ Tech Stack and Framework Strategy

* **C# .NET**
* **NUnit Framework**
* **Selenium**
* **Reqnroll (BDD Framework)**
* **ExtentReports**
* **Page Object Model (POM)**

---

## 🔍 Notes

* This framework is a good starting point for scalable UI test automation projects.
* Additional scenarios and features can be easily added by following the existing structure.

---
