extends Control

signal install_signal
signal uninstall_signal

const SLOT_EMPTY = preload("res://scenes/house/Kitchen/tool_slot_empty.tscn")
const SLOT_NOT_USED = preload("res://scenes/house/Kitchen/tool_not_used.tscn")
const SLOT_USED = preload("res://scenes/house/Kitchen/tool_is_used.tscn")

@onready var slot = $P/M/V/Slot

var largeslots: Dictionary
var largetools: Array
var installedId: Array
var installedName: Array
var installedToolsInfo: Array

var selectedSpace: int

func _ready():

	load_data()

# Setting Slots
	set_slot("first")
	set_slot("second")
	set_slot("third")
	
	SceneContext.installed_tool_id = installedId
	SceneContext.installed_tool_name = installedName
	SceneContext.installed_tool_info = installedToolsInfo

	
func load_data():
	largeslots = SceneContext.user_kitchen_state["villageState"]["houseState"]["kitchenState"]
	
	var tools = SceneContext.user_state["inventoryState"]["kitchenEquipmentStateList"]
	for tool in tools:
		if(tool.equipmentCategoryType == "main"):
			largetools.append(tool)

func set_slot(name : String):
	var loc = "%s%s" % [name,"ApplianceSpace"]
	var singleslot = largeslots[loc]
	if (singleslot.installedKitchenEquipment == null): # not installed
		var bigslot = SLOT_EMPTY.instantiate()
		bigslot.install_tools.connect(on_signal_received)
		bigslot.set_data(singleslot)
		slot.add_child(bigslot)
	else: # installed but not used
		if (!singleslot["installedKitchenEquipment"]["isCooking"]):
			var bigslot = SLOT_NOT_USED.instantiate()
			bigslot.set_data(singleslot)
			slot.add_child(bigslot)
			bigslot.uninstall_big_tool_button_pressed.connect(on_uninstall_signal_recived)
			installedId.append(singleslot["installedKitchenEquipment"]["stateId"])
			installedName.append(singleslot["installedKitchenEquipment"]["equipmentName"])
			var dict = { "name" : singleslot["installedKitchenEquipment"]["equipmentName"],
				"stateId" : singleslot["installedKitchenEquipment"]["stateId"],
			"isCooking" : singleslot["installedKitchenEquipment"]["isCooking"],
			"foodId" : null}
			
			installedToolsInfo.append(dict)
		else: # cooking
			var bigslot = SLOT_USED.instantiate()
			bigslot.set_data(singleslot)
			slot.add_child(bigslot)
			var dict = { "name" : singleslot["installedKitchenEquipment"]["equipmentName"],
				"stateId" : singleslot["installedKitchenEquipment"]["stateId"],
			"isCooking" : singleslot["installedKitchenEquipment"]["isCooking"],
			"foodId" : singleslot["installedKitchenEquipment"]["cookingFood"]["stateId"]}
			
			installedToolsInfo.append(dict)
			
func on_signal_received(spaceNumber : int):
	install_signal.emit(spaceNumber)

func on_uninstall_signal_recived(spaceNumber : int):
	uninstall_signal.emit(spaceNumber)
