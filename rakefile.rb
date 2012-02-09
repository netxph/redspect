Dir.glob('*.rake').each do |r|
  import r
end

desc 'default'
task :default => [:build]

desc 'build'
task :build do
  sh 'msbuild redspect.sln'
end

desc 'rebuild'
task :rebuild do
  sh 'msbuild redspect.sln /t:clean;rebuild'
end

desc 'test'
task :test do
  cd 'bin/debug'
  sh 'xunit.console.clr4.exe RedSpect.Tests.dll'
end
