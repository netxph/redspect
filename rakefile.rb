desc 'default task'
task :default => [:build]

desc 'build'
task :build do
  sh 'msbuild'
end

desc 'rebuild'
task :rebuild do
  sh 'msbuild /t:clean;rebuild'
end

desc 'run console'
task :runcon do
  cd 'bin/debug'
  sh 'RedSpect.Client.Console.exe'
end
