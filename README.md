# Logitech Craft Unity plugin

Unity plugin that adds Logitech Craft keyboard support to the editor

## Installation

1. [Enable keyboard developer mode](https://github.com/Logitech/logi_craft_sdk/blob/master/samples/WinFormsCrownSample/README.md#4-enable-developer-mode)
2. Click + inside editor package manager window and select "Add package from git URL..."
3. Enter `https://github.com/r1noff/UnityCraft.git` and click add button
4. After package successfully installs go to `Library/PackageCache/com.r1noff.unitycraft@1.0.0` and run `InstallPlugin.bat` It will create symlink of manifest folder into the LogiOptionsPlugins folder (you also can just copy it manually, [for details see official SDK documentation](https://github.com/Logitech/logi_craft_sdk/blob/master/documentation/Craft_Crown_SDK.md))
5. Run  `RestartLogitechOptions.bat` or restart logitech options app by yourself

## Usage

The plugin selects what the crown is responsible for, depending on the state of the editor (by priority from top to bottom)

| Icon                                                                                         | Сondition                                            | Turn left                                   | Turn right                              |
|----------------------------------------------------------------------------------------------|------------------------------------------------------|---------------------------------------------|-----------------------------------------|
| [Scale](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Gallery/scale.png)         | Left mouse button is pressed on selected game object | Decrease game object scale                  | Increase game object scale              |
| [Profiler](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Gallery/profiler.png)   | Mouse is over profiler window                        | Select previous profiler frame              | Select next profiler frame              |
| [Animation](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Gallery/animation.png) | The animation window is opened and clip is selected  | Move playback head to the previous keyframe | Move playback head to the next keyframe |
| [Project](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Gallery/project.png)     | File or folder selected                              | Select previous file/folder                 | Select next file/folder                 |
| [Hierarchy](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Gallery/hierarchy.png) | By default                                           | Select previous hierarchy object            | Select next hierarchy object            |


## Development

To create a new tool:
1. Clone the repository into the `Packages` folder of your project
2. Add the tool name locale to [`en.json`](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Languages/en.json)
3. Add the tool to [`tools.json`](./LogiOptionsPlugin~/4ddb3e7f-0971-4b68-a2eb-90b29fc9bbb8/Manifest/tools.json)
4. Implement the [`ITool`](./Editor/Tools/ITool.cs) interface
5. Add a tool field to the [`Tools.cs`](./Editor/Tools.cs) file and a condition for selecting it to the `SelectTool()` method

## Contributing

Feel free to contribute fixes as well as your tools. To create a pull request for a tool you also need to create an icon according to [Logitech guidelines](https://github.com/Logitech/logi_craft_sdk/blob/master/documentation/Craft_Crown_SDK.md#7-design-guidelines). You can use my [figma file](https://www.figma.com/file/w1K6HUJv8VAJQxr17clOnn/UnityCraft-Icons?type=design&node-id=2%3A1198&mode=design&t=pPRTvX1E13anQNcp-1)

## License

[MIT License](./LICENSE.md)

