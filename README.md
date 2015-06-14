# PMDCP Core Client

## Downloading

To download this repository, run:
```
git clone --recursive https://github.com/pmdcp/Client
```
This will download the core client files, as well as all dependancies.

## Configuring Your Client

You can change the connection settings in the *settings.xml* file. It is found in the *resources* folder.

You can update the game name in the *Client\Constants.cs* file. You will need to recompile the client for the changes to take effect.

## Compiling Your Client

Install [Visual Studio](https://www.visualstudio.com). Once installed, launch *Client.sln*. In the Visual Studio interface, change *Debug* to *Release*. Build the client. Output files will be placed in *Client\bin\Release*.

That's it! Your client is setup and can now be run!
