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
   ```

## Integrate with PHP

To integrate the C# application with a PHP application, you can call the executable using PHP's `shell_exec()` function.

### Example PHP Script: `sendSMS.php`

Here’s an example PHP script to run the C# executable and send an SMS:

```php
<?php

$port = 'COM6'; // Example port, replace with actual port
$guardianNumber = '09911234567'; // Replace with actual phone number

// Path to your compiled C# executable
$exePath = realpath('lib/SendSMSApp.exe'); // Ensure the path is correct

// Build the command to execute the C# program with parameters
$command = escapeshellcmd("{$exePath} {$port} {$guardianNumber}");

// Execute the C# executable
$output = shell_exec($command);

// Check if the execution was successful and display the result
if ($output) {
    echo "Message sent successfully!";
} else {
    echo "Failed to send the message.";
}
?>
```

## Steps to Run

Ensure the `SendSMSApp.exe` is compiled and placed in the correct directory.

Update the PHP script with the correct path to the `.exe` file.

When the `sendSMS.php` file is triggered (via web browser or API), it will send an SMS to the specified phone number.

## Running the System

Place the compiled `.exe` file (e.g., `SendSMSApp.exe`) in your project directory or a known location.

## Note: 
When you compile the C# file. copy everything it generated like the screenshot below. Place these files
inside your project or have a folder named "lib/SendSMSAPI" and put the files there.

![image](https://github.com/user-attachments/assets/33582882-2707-4277-8521-568d3f53f55b)


Ensure that the PHP script (`sendSMS.php`) is set up to call the `.exe` file.

Execute the PHP script via your browser or API endpoint.

The recipient will receive the SMS message, and the system will print the result on the browser.

## Troubleshooting

- **Port Issues**: Make sure the serial port is correctly configured and accessible.
- **GSM Modem**: Ensure that the GSM modem is powered on and connected to the correct port.
- **Permissions**: Ensure that the server running PHP has permission to execute the C# executable.
