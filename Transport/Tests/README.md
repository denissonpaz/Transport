# Test for Transport Console Application

Automating some applications could be tiresome and sometimes it requires more than one solution or tool to achieve better results.
For the automation of this Tranport Console Application, AutoIT is the chosen one.

# Manual Scenarios

All test cases are available in the Excel files of this Test folder

## Test Cases

### TEST CASE 01
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 02
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 03
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 04
```
Title:         List out the Flight Schedules

Description:   The inventory Manager will List out the flight schedules.
```

### TEST CASE 05
```
Title:         List out a flight scheduled with no Flights Loaded

Description:   The inventory Manager will List out the flight schedules with no Flights Loaded.
```

### TEST CASE 06
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 07
```
Title:         Generate the itinerary

Description:   The inventory Manager will List out the itinerary of all flights.
```

### TEST CASE 08
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 09
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 10
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.
```

### TEST CASE 11
```
Title:         Exit Application

Description:   The user will exit application.
```

# Automated Scenarios

## Built With
* [AutoIT](https://www.autoitscript.com/site/) Version **3.3.15.2**

## Getting Started

### Prerequisites
* [AutoIT3.exe](AutoIT3.exe) Located on the root of this folder


## Usage

### Usage Stand Alone

Via command line or using a batch file, in order to launch a test case, you can follow the example below

```bash
	AutoIt3.exe scripts\tests.a3x -test "01"
```

## Available Test Cases on AutoIT Script

### TEST CASE 01
```
Title:         Load a Flight Schedule

Description:   The inventory Manager will load a flight schedule into the application.

Args:          None

Returns:       "Passed" or "Failed"
				
Command:       AutoIt3.exe scripts\tests.a3x -test "01"
```

### TEST CASE 04
```
Title:         List out the Flight Schedules

Description:   The inventory Manager will List out the flight schedules.

Args:          None

Returns:       "Passed" or "Failed"
				
Command:       AutoIt3.exe scripts\tests.a3x -test "04"
```

### TEST CASE 05
```
Title:         List out a flight scheduled with no Flights Loaded

Description:   The inventory Manager will List out the flight schedules with no Flights Loaded.

Args:          None

Returns:       "Passed" or "Failed"
				
Command:       AutoIt3.exe scripts\tests.a3x -test "05"
```

### TEST CASE 07
```
Title:         Generate the itinerary

Description:   The inventory Manager will List out the itinerary of all flights.

Args:          None

Returns:       "Passed" or "Failed"
				
Command:       AutoIt3.exe scripts\tests.a3x -test "07"
```

## After running the Script
- It will return "**Passed**" or "**Failed**".
  - The status of the executed script will be available on the screen for 10 seconds and in the Result folder, inside the file **status.dp**


- It will generate a detailed error descript.
  - The error description will be available in inside the file **errorm.dp**

- In case of the call used recover any data from the screen, this data will be saved as well.
  - The content recovered during the execution of the script will be available in inside the file **wcontent.dp**


## Contributing
These scripts are part of an exercise for the process interview for AirTek. Feel free to add any comments or changes.

## License
MIT