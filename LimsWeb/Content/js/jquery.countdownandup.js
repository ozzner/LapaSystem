(function($) {

    $.fn.countDownAndUp = function( options ) {

        var settings = $.extend({
            since         : null,
            until        : null
        }, options);
		
		var future = settings.until;
		var now = settings.since;
		var difference;
		var difference2;
			
		/* Los datos para el retroceso */
		var seconds;
		var minutes;
		var hours;
		
		var esto = $(this);
		esto.css({"font-size":"20px"});
		esto.append("<span></span>");
		esto.append("<span></span>");
		esto.append("<span></span>");
		esto.append("<span></span>");
		
		//console.log(future);
		
		setInterval(function(){
			
				difference = Math.floor((future.getTime() - now.getTime()) / 1000);
				difference2 = Math.floor((now.getTime() - future.getTime()) / 1000);
			
				//console.log(future.getTime());
				//console.log(now.getTime());
				
				if(difference >= 0 && difference2 <= 0){
					
					esto.css({"color":"green"});
					
					seconds = fixIntegers(difference % 60);
					difference = Math.floor(difference / 60);
						
					minutes = fixIntegers(difference % 60);
					difference = Math.floor(difference / 60);
						
					hours = fixIntegers(difference % 24);
					difference = Math.floor(difference / 24);
					
					esto.find("span:eq(3)").text(seconds);
					esto.find("span:eq(2)").text(minutes+ ":");
					esto.find("span:eq(1)").text(hours+ ":");
				
					now.setSeconds(now.getSeconds()+1);						
				
				} else if(difference2 >= 0 && difference <= 0) {
					
					esto.css({"color":"red"});
					esto.find("span:eq(0)").text("-");
					
					seconds = fixIntegers(difference2 % 60);
					difference2 = Math.floor(difference2 / 60);
						
					minutes = fixIntegers(difference2 % 60);
					difference2 = Math.floor(difference2 / 60);
						
					hours = fixIntegers(difference2 % 24);
					difference2 = Math.floor(difference2 / 24);
					
					esto.find("span:eq(3)").text(seconds);
					esto.find("span:eq(2)").text(minutes+ ":");
					esto.find("span:eq(1)").text(hours+ ":");
				
					future.setSeconds(future.getSeconds()-1);
				}
				
			}, 1000);
			
			function formatTime(time){
				var time_t = time.length;
				
				if ( time < 10 && time_t == undefined){ 
					 time = "0"+time;
				} else if ( time < 10 && time_t != undefined ){
					time = time;
				}
				return time;
			}
			
			function fixIntegers(integer) {
				if (integer < 0)
					integer = 0;
				if (integer < 10 )
					return "0" + integer;
				return "" + integer;
			}
    }

}(jQuery));