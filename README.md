# ImageChanger
## Image Changer is a web-based image processing application that allows users to upload images, change their format, and resize them according to specific parameters. It supports various image formats like JPEG, PNG, GIF. Built using Blazor and .NET.
## Features
- Upload and display images.
- Change image format to various supported formats (JPEG, PNG, GIF).
- Resize images with options:
  - Max width or height.
  - Specific dimensions (width and height).
- Download the processed images in the new format.
## Technologies Used
- **Blazor** (Interactive web UI)
- **ASP.NET Core** (Backend server)
- **.NET System.Drawing** (Image processing and conversion)
- **Bootstrap** (UI styling)
## Getting Started

### Prerequisites

To run this project locally, you'll need the following:

- **.NET 7.0 SDK** or higher
- **Visual Studio** or **Visual Studio Code** with the necessary extensions for Blazor
- **NuGet packages**:
  - `System.Drawing.Common`
###Installation
1. Clone the repository:
```bash
git clone https://github.com/DAART15/ImageChanger.git
cd image-changer
```
2. Restore the dependencies:
```bash
dotnet restore
```
3. Build the project:
```bash
dotnet build
```
4. Run the application:
```bash
dotnet run
```
5. Open your browser and navigate to: localhost:5084.

## Usage

1. **Upload an Image:** Choose an image to upload. The image details (name, size, dimensions, etc.) will be displayed.
2. **Select Conversion Options:**
    - Change Format: You can convert the image to different formats (JPEG, PNG, GIF).
    - Resize: You can resize the image by specifying maximum width/height or providing specific dimensions.
3. **Download:** After processing, click the "Download" button to save the image in the new format.

## ***Supported Output Formats:*** **JPEG, PNG, GIF**
## Contributing
Contributions, issues, and feature requests are welcome!
**To contribute:**
1. Fork this repository.
2. Create your feature branch.
3. Commit your changes.
4. Push to the branch.
5. Open a pull request.
