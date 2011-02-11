class Messenger
   attr_reader :message
   
   def initialize(message)
      @message = message
   end 
end

messenger = Messenger.new("Hello world!")
puts messenger.message