var CODAPManagerPlugin= {
	Init: function()
	{
		DefendersGame.codapPhone.call({
			"action": "update",
			"resource": "interactiveFrame",
			"values": 
			{
				"name": "Defenders",
				"version": "1.0",
				"preventBringToFront": false,
				"preventDataContextReorg": false,
				"cannotClose": true,
				"dimensions": 
				{
					"width": 1000,
					"height": 580
				}
			}
		}, function(){console.log("Initializing game")});
	},

	CreateDataContext: function()
	{
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContext",
			"values": {
				"name": "SessionData",
				"title": "Session Data",
				"collections": [ 
				{
					"name": "Games",
					"attrs": [
						{ "name": "gameNum", "type": "numeric", "precision": 0 },
						{ "name": "level", "type": "categorical" }
					]
				},
				{
					"name": "Tower",
					"parent": "Games",
					"labels": {
						"singleCase": "tower",
						"pluralCase": "towers"
					},
					"attrs": [
						{ "name": "playerID", "type": "categorical"},
						{ "name": "groupID", "type": "categorical"},
						{ "name": "wave", "type": "numeric", "precision": 0 },
						{ "name": "funds", "type": "numeric", "precision": 0 },
						{ "name": "health", "type": "numeric", "precision": 0 },
						{ "name": "position", "type": "numeric", "precision": 0 },
						{ "name": "turretType", "type": "categorical" },
						{ "name": "upgrade", "type": "categorical" },
						{ "name": "medicine", "type": "categorical" },
						{ "name": "virus", "type": "categorical" },
						{ "name": "count", "type": "numeric", "precision": 0 },
						{ "name": "shot", "type": "numeric", "precision": 0 },
						{ "name": "destroyed", "type": "numeric", "precision": 0 }
					]
				}]
			}
		}, function(){console.log("Creating session data")});
	},

	SendGameData: function(gameNum, level)
	{
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContext[SessionData].collection[Games].case",
			"values":[
				{
					"values": {
						"gameNum": gameNum,
						"level": level
					}
				}
			]
		}, function(result){
			if(result !== undefined)
			{
				openGameCase = result.values[0].id;
				console.log(result.success);
				console.log("I have caseID" + result.values[0].id);
			}
		});
	},

	SendLevelData: function(playerID, groupID, wave, funds, health, position, turretType, upgrade, medicine, virus, count, shot, destroyed)
	{
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContext[SessionData].collection[Tower].case",
			"values":[
				{
					"parent": openGameCase,
					"values": {
						"playerID": Pointer_stringify(playerID),
						"groupID": Pointer_stringify(groupID),
						"wave": wave,
						"funds": funds,
						"health": health,
						"position": position,
						"turretType": Pointer_stringify(turretType),
						"upgrade": Pointer_stringify(upgrade),
						"medicine": Pointer_stringify(medicine),
						"virus": Pointer_stringify(virus),
						"count": count,
						"shot": shot,
						"destroyed": destroyed
					}
				}
			]
		}, function(){console.log("CODAP Data Sent")});
	},

	CODAPSendDataAll: function()
	{		
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContextFromURL",
			"values": {
				"name": "All Data",
				"URL": "https://stat2games.sites.grinnell.edu/data/defenders/getdata.php"
			}
		}, function(){console.log("Send data")});
	},

	CODAPSendDataPlayer: function(playerID)
	{		
		var str = "https://stat2games.sites.grinnell.edu/data/defenders/getdata.php?player=" + Pointer_stringify(playerID);
		console.log(playerID);
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContextFromURL",
			"values": {
				"name": "Player Data",
				"URL": str
			}
		}, function(){console.log("Send player data")});
	},

	CODAPSendDataGroup: function(groupID)
	{		
		var str = "https://stat2games.sites.grinnell.edu/data/defenders/getdata.php?group=" + Pointer_stringify(groupID);
		console.log(groupID);
		DefendersGame.codapPhone.call({
			"action": "create",
			"resource": "dataContextFromURL",
			"values": {
				"name": "Group Data",
				"URL": str
			}
		}, function(){console.log("Send group data")});
	}
};

mergeInto(LibraryManager.library, CODAPManagerPlugin);