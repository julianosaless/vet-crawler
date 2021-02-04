class Build {

  static buid() {
    const childProcess = require("child_process");
    const scriptProcess = childProcess.spawn('cmd.exe', ['/c', "dotnet build"], {
      env: process.env,
      windowsVerbatimArguments: true
    });

    scriptProcess.stdout.on('data', function (data) {
      console.log('stdout: ' + data);
    });

    scriptProcess.stderr.on('data', function (data) {
      console.log('stderr: ' + data);
      process.exit(1);
    });

    scriptProcess.on('close', function (code) {
      console.log('child process exited with code ' + code);
    });
  }

  static restore() {
    const childProcess = require("child_process");
    const scriptProcess = childProcess.spawn('cmd.exe', ["/c", "dotnet restore"], {
      env: process.env,
      windowsVerbatimArguments: true
    });

    scriptProcess.stdout.on('data', function (data) {
      console.log('stdout: ' + data);
    });

    scriptProcess.stderr.on('data', function (data) {
      console.log('stderr: ' + data);
      process.exit(1);
    });

    scriptProcess.on('close', function (code) {
      console.log('child process exited with code ' + code);
    });
  }
  static deploy() {
    const childProcess = require("child_process");
    const scriptProcess = childProcess.spawn('cmd.exe', ['/c', "dotnet pack"], {
      env: process.env,
      cwd: '.\\src\\UI\\VetDirectoryTool.CLI',
      windowsVerbatimArguments: true
    });

    scriptProcess.stdout.on('data', function (data) {
      console.log('stdout: ' + data);
    });

    scriptProcess.stderr.on('data', function (data) {
      console.log('stderr: ' + data);
      process.exit(1);
    });

    scriptProcess.on('close', function (code) {
      console.log('child process exited with code ' + code);
    });
  }

  static install() {
    const childProcess = require("child_process");
    const scriptProcess = childProcess.spawn('cmd.exe', ['/c', "dotnet tool install -g vetDirectory.dotnet.CLI --add-source .\nupkg"], {
      env: process.env,
      cwd: '.\\src\\UI\\VetDirectoryTool.CLI',
      windowsVerbatimArguments: true
    });

    scriptProcess.stdout.on('data', function (data) {
      console.log('stdout: ' + data);
    });

    scriptProcess.stderr.on('data', function (data) {
      console.log('stderr: ' + data);
    });

    scriptProcess.on('close', function (code) {
      console.log('child process exited with code ' + code);
    });
  }
  static uninstall() {
    const childProcess = require("child_process");
    const scriptProcess = childProcess.spawn('cmd.exe', ['/c', "dotnet tool uninstall -g vetDirectory.dotnet.CLI"], {
      env: process.env,
      cwd: '.\\src\\UI\\VetDirectoryTool.CLI',
      windowsVerbatimArguments: true
    });

    scriptProcess.stdout.on('data', function (data) {
      console.log('stdout: ' + data);
    });

    scriptProcess.stderr.on('data', function (data) {
      console.log('stderr: ' + data);
    });

    scriptProcess.on('close', function (code) {
      console.log('child process exited with code ' + code);
    });
  }
}

process.argv.forEach((val, index, array) => {
  switch (val) {
    case 'build':
      Build.buid();
      break;
    case 'restore':
      Build.buid();
      break;
    case 'deploy':
      Build.deploy();
      break;
    case 'install':
      Build.install();
      break;
    case 'uninstall':
      Build.uninstall();
      break;
  }
});

