# SMS Sender API (via Serial Port)

This project allows you to send SMS messages via a serial port using a C# application. The program takes a COM port, a recipient's phone number, and sends a predefined SMS message to the recipient.

## Features

- Sends SMS using a GSM modem connected via a serial port.
- Configurable port and recipient's phone number.
- Easy integration with PHP backend to send SMS from a web application.

## Requirements

- .NET Framework 4.8 (or higher).
- A GSM modem or mobile phone connected to the computer via a serial port.
- PHP running on your server.
- Composer for managing PHP dependencies (if necessary).

## C# Application Setup

### 1. Compile the C# Application

1. Open the `SendSMSApp` project in Visual Studio.
2. Compile the project to generate the executable file (`SendSMSApp.exe`).
3. Ensure the C# application can be run using a command like:

   ```bash
   SendSMSApp.exe COM8 your_mobile_number_here
