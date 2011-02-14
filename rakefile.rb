Dir.glob('rake/*.rake').each { |r| import r }

desc 'default task'
task :default => [:build]

desc 'build'
task :build do
  cp_r 'lib/4.0/'+"/.", './lib/'
  sh 'msbuild'
end

desc 'rebuild'
task :rebuild do
  cp_r 'lib/4.0/'+"/.", './lib/'
  sh 'msbuild /t:clean;rebuild'
end

desc 'run console'
task :runcon do
  cd 'bin/debug'
  sh 'RedSpect.Client.Console.exe'
end

desc 'build for .net 3.5'
task :build35 do
  cp_r 'lib/3.5/'+"/.", './lib/'
  sh 'msbuild /p:TargetFrameworkVersion="v3.5"'
end

desc 'rebuild for .net 3.5'
task :rebuild35 do
  cp_r 'lib/3.5/'+"/.", './lib/'
  sh 'msbuild /t:clean;rebuild /p:TargetFrameworkVersion="v3.5"'
end

desc 'rebuild release'
task :release do
  cp_r 'lib/4.0/'+"/.", './lib/'
  sh 'msbuild /t:clean;rebuild /p:Configuration="Release"'
end

desc 'rebuild release for 3.5'
task :release35 do
  cp_r 'lib/3.5/'+"/.", './lib/'
  sh 'msbuild /t:clean;rebuild /p:Configuration="Release";TargetFrameworkVersion="v3.5"'
end
