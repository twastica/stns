var result = "";
var actionList = ["on1","off1","on2","off2"];
for(var states = 0 ; states < 8 ; states++){
	for(var rain = 0 ; rain < 2 ; rain++){
		for(var actions=0;actions<4;actions++){
			var targetState ="";
			if(actions==0){
				if(states==2 || states==3 || states==6 || states==7)
					targetState=states;
				else
					targetState=states+2
			}
			else if(actions==2){
				if(states==1 || states==3 || states==5 || states==7)
					targetState=states;
				else
					targetState=states+1;
			}
			else if(actions==1){
				if(states==0 || states==1 || states==4 || states==5)
					targetState=states;
				else
					targetState=states-2;
			}
			else if(actions==3){
				if(states==0 || states==2 || states==4 || states==6)
					targetState=states;
				else
					targetState=states-1;
			}

			targetState += (states<4 && rain==1)?4:(states>3 && rain==0)?-4:0;

			var prob = 0;
			if(states+4==targetState)
				prob+=0.4;
			else if(states-4==targetState)
				prob+=0.1;
			else if(states > 3)
				prob+=0.3;
			else if(states < 4)
				prob+=0.2;
			else
				prob+=0.1;
				
				
			result+=("S"+states+","+actionList[actions]+",S"+targetState+","+prob+"\n");
		}
	}
}

console.log(result);
