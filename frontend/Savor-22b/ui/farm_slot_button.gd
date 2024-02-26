extends ColorRect

signal button_down(child_index: int)

@onready var button = $V/Button

var farm_slot: Dictionary

var format_string = """%s %s
	(%d %s)"""
	
var isleft: bool

func _ready():
	_update_button()

func _update_button():
	if button == null:
		return

	button.text = format_string % [farm_slot.seedName, "자라는 중", farm_slot.totalBlock, "블록 남음"]
	

func set_farm_slot(farm_slot: Dictionary):
	self.farm_slot = farm_slot
	_update_button()

func _on_button_button_down():
	if (isleft):
		button_down.emit(get_index())
	else:
		button_down.emit(get_index()+5)



func im_right():
	isleft = false

func im_left():
	isleft = true
