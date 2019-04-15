include irvine32.inc
.data

Three DWORD 3

PixelValue DWORD 255

;remove noise variables

elements dword ?
window dword 1000 dup (?)
median dword ?
nextRow dword ?
firstIndex dword ?
sumWindow dword ?
midPixel dword ?
index dword ?
imageWidth dword ?
imageHight dword ?


.code

;-----------------------------------------------------
;GrayScale PROC Converts Image into Gray Scale 
;Recieves: Three array each of them contains a Pixel Component Of RGB
;           ESI contains the OFFSET of the Red component array.
;           EDI contains the OFFSET of the Green component array.
;           EBX contains the OFFSET of the Blue component array.
;           EAX used as an accumelator to sum the RGB Values of each Pixel then Divide it over 3 to get the average Value 
;                          of each Pixel.
;           ECX Used to initialize the ApplyGrayScale LOOP with the lengthof the recieved array.
;           EDX initialized with zeros to Avoid OverFlow while Dividing.
;Returns: an Image after Applying the grayScale on it
;
;------------------------------------------------------
GrayScale PROC USES ESI EDI EAX EBX ECX EDX, RedArray:PTR DWORD, GreenArray:PTR DWORD , BlueArray:PTR DWORD, sz:DWORD

MOV ESI , RedArray
MOV EDI , GreenArray
MOV EBX , BlueArray
MOV EAX ,0                    ;;To initialize a Counter
MOV EDX ,0                    ;;To Avoid OverFlow while Dividing
MOV ECX ,sz

  ApplyGrayScale :
        
		ADD eax,[ESI]
		ADD eax,[EDI]
		ADD eax,[EBX]
		DIV Three            ;;Divide EAX By 3 To get the Averge Colour

		MOV [ESI],eax
		MOV [EDI],eax
		MOV [EBX],eax

		add ESI, dword
		add EDI, dword
		add EBX, dword
		MOV EAX,0             ;;Re-Initializing the Counter
		mov edx, 0

  LOOP ApplyGrayScale
Ret
GrayScale ENDP

;-------------------------------------------------------------------------------------------------------------
;AdjustBrightness PROC Adjusts the Brightness of an Image either by Increasing the Brightness or Decreasing it
;Recieves: Three Arrays each contains a component of the RGB pixels forming the Image
;	brightnessValue_RA: The value of brightness (could be positive or negative) that will be added on all pixels
;	arrSize_RA: The size of the three arrays (All of equal sizes)
;	red_RA: a pointer to the array that contains the red components of all the pixels
;	blue_RA: a pointer to the array that contains the blue components of all the pixels
;	green_RA: a pointer to the array that contains the green components of all the pixels
;	EAX: holds the brightness value (brightnessValue_RA)
;	ESI: holds the the OFFSET of each array (initialized before each loop)
;	ECX: used as a counter for each loop
;	EBX: holds the value of each component of the each array in its specified loop
;-------------------------------------------------------------------------------------------------------------
AdjustBrightness PROC USES EAX ESI ECX EBX, brightnessValue_RA:SDWORD, arrSize_RA:DWORD, red_RA:PTR DWORD, blue_RA:PTR DWORD, green_RA:PTR DWORD

	mov eax, brightnessValue_RA

	Red_Adjustment:
		mov esi, red_RA			;;OFFSET of the array containing the red components of all pixels
		mov ecx, arrSize_RA		;;Number of Loops required
		mov ebx, 0				;;To remove any unwanted values in the register

		redLoop:
			mov ebx, [esi]
			add ebx, eax
			cmp ebx, 255
			jg setMaxValue		;;If the value is greater than 255 then change this value to 255
			jl semiDone			;;Go and compare it to zero

			setMaxValue:
				mov ebx, 255
				mov [esi], ebx
				jmp next
			semiDone:
				cmp ebx, 0
				jl setMinValue	;;If the value is negative then change this value to 0
				mov [esi], ebx	;;Else leave the value as it's and jump to the end of the loop
				jmp next
			setMinValue:
				mov ebx, 0
				mov [esi], ebx

			next:
				add esi,dword
		Loop redLoop

	Green_Adjustment:
		mov esi, green_RA		;;OFFSET of the array containing the green components of all pixels
		mov ecx, arrSize_RA		;;Number of Loops required
		mov ebx, 0				;;To remove any unwanted values in the register

		greenLoop:
			mov ebx, [esi]
			add ebx, eax
			cmp ebx, 255
			jg setMax			;;If the value is greater than 255 then change this value to 255
			jl lastCheck		;;Go and compare it to zero

			setMax:
				mov ebx, 255
				mov [esi], ebx
				jmp done
			lastCheck:
				cmp ebx, 0
				jl setMin		;;If the value is negative then change this value to 0
				mov [esi], ebx	;;Else leave the value as it's and jump to the end of the loop
				jmp done
			setMin:
				mov ebx, 0
				mov [esi], ebx

			done:
				add esi, dword
		Loop greenLoop

	Blue_Adjustment:
		mov esi, blue_RA		;;OFFSET of the array containing the blue components of all pixels
		mov ecx, arrSize_RA		;;Number of Loops required
		mov ebx, 0				;;To remove any unwanted values in the register
		
		blueLoop:
			mov ebx, [esi]
			add ebx, eax
			cmp ebx, 255
			jg setMaximum		;;If the value is greater than 255 then change this value to 255
			jl checkZero		;;Go and compare it to zero

			setMaximum:
				mov ebx, 255
				mov [esi], ebx
				jmp finish
			checkZero:
				cmp ebx, 0
				jl setMinimum	;;If the value is negative then change this value to 0
				mov [esi], ebx	;;Else leave the value as it's and jump to the end of the loop
				jmp finish
			setMinimum:
				mov ebx, 0
				mov [esi], ebx
			finish:
				add esi, dword
		Loop blueLoop	

	ret
AdjustBrightness ENDP

;--------------------------------------------------------------------------------------------------------------------
;ImageInvert PROC Subtracts from each pixel 255
;Recieves:  Three array each of them contains a Pixel Component Of RGB
;           ESI contains the OFFSET of the Red component array.
;           EDI contains the OFFSET of the Green component array.
;           EBX contains the OFFSET of the Blue component array.
;    
;           ECX Used to initialize the ApplyNegativity LOOP with the lengthof the recieved array.
;          
;Returns: an Image after Applying the grayScale on it
;---------------------------------------------------------------------------------------------------------------------
ImageInvert  PROC  USES ESI EDI EAX EBX ECX EDX , RedArray_S:PTR DWORD  , GreenArray_S:PTR DWORD ,
                                                  BlueArray_S:PTR DWORD , Size_S:DWORD

MOV ESI , RedArray_S
MOV EDI , GreenArray_S
MOV EBX , BlueArray_S
MOV EAX ,0                    ;;To initialize a Counter


MOV ECX , Size_S

  ApplyNegativity  :
        MOV EAX , PixelValue
        SUB EAX , [ESI]
		MOV [ESI], EAX

		MOV EAX , PixelValue
        SUB EAX , [EDI]
		MOV [EDI], EAX

		MOV EAX , PixelValue
        SUB EAX , [EBX]
		MOV [EBX], EAX

		ADD ESI , DWORD
		ADD EDI , DWORD
		ADD EBX , DWORD

  LOOP ApplyNegativity 

Ret
ImageInvert  ENDP

;--------------------------------------------------------------------------------------------------------------------
;ImageAddition PROC Adds two Images to get a new Image
;Recieves:  Two arrays each of them contains a Pixel Component Of RGB 
;           ESI contains the OFFSET of the the first array which contains One Pixel Component of the 1st image.
;           EDI contains the OFFSET of the the second array which contains One Pixel Component of the 2nd image.        
;           EAX used as an accumelator to sum the The pixel Component's Values of each Pixel.
;    
;           ECX Used to initialize the ApplyAddition LOOP with the lengthof the recieved array.
;          
;How it works : we will call it 3 Times each Time with a different Pixel Component.
;Returns: an array after adding One Pixel Component from the 2 Images to each other so, it contains the summution.
;NOTE THAT : I'll return the new array at Array1 too.
;---------------------------------------------------------------------------------------------------------------------
ImageAddition PROC  USES ESI EDI EAX EBX ECX EDX , Array1_ResArr_S:PTR DWORD, Array2_S:PTR DWORD , Size_S:DWORD

MOV ESI ,  Array1_ResArr_S
MOV EDI ,  Array2_S
MOV EAX ,0                    ;;To initialize a Counter

MOV ECX , Size_S

  ApplyAddition :
        
		MOV EAX,[ESI]
		ADD EAX,[EDI]
		cmp eax, 255
		ja l2

		MOV [ESI],EAX
		jmp skip

		l2:
			mov ebx, 255
			mov [esi], ebx

		skip:
			ADD ESI , DWORD
			ADD EDI , DWORD

			MOV EAX , 0

  LOOP ApplyAddition

Ret
ImageAddition ENDP

;--------------------------------------------------------------------------------------------------------------------
;ImageSubtraction PROC Subtracts two Images from each other and produces as output a third image
;Recieves:  Two arrays each of them contains a Pixel Component Of RGB 
;           ESI contains the OFFSET of the the first array which contains One Pixel Component of the 1st image.
;           EDI contains the OFFSET of the the second array which contains One Pixel Component of the 2nd image.        
;           EAX used to substract the The pixel Component's Value of the 2nd image 
;                                from The pixel Component's Value of the 1st image.
;    
;           ECX Used to initialize the ApplySubtraction LOOP with the lengthof the recieved array.
;          
;How it works : we will call it 3 Times each Time with a different Pixel Components.
;NOTE THAT : I'll return the new array at Array1 too.
;---------------------------------------------------------------------------------------------------------------------
ImageSubtraction  PROC  USES ESI EDI EAX EBX ECX EDX , Array1_ResArr_S:PTR DWORD, Array2_S:PTR DWORD , Size_S:DWORD

MOV ESI ,  Array1_ResArr_S
MOV EDI ,  Array2_S
MOV EAX ,0                    ;;To initialize a Counter

MOV ECX , Size_S

  ApplySubtraction  :
        
		MOV EAX,[ESI]
		SUB EAX,[EDI]
		cmp eax, 0
		jl l2

		MOV [ESI],EAX
		jmp skip

		l2:
			mov ebx, 0
			mov [esi], ebx

		skip:
			ADD ESI , DWORD
			ADD EDI , DWORD

			MOV EAX , 0

  LOOP ApplySubtraction 

Ret
ImageSubtraction  ENDP

;RemoveNoise 


;------------------------------------------------------------------;
;	a function that read variables and then compute some constant  ;
;		variables that we will use it in the computations		   ;
;------------------------------------------------------------------;

computeConst PROC uses eax  ebx  ecx edx esi edi, imageWidthh:dword, imageHeight:dword, border:dword

	mov eax, imageWidthh
	mov imageWidth, eax

	mov eax, imageHeight
	mov imageHight, eax

	mov eax, border
	mov index, eax
	
	mov eax, 0
	
	comment @
	; get width
	mov edx , offset msg1
	call writeString
	call readdec
	mov imageWidth , eax
	call crlf

	;get hight
	mov edx , offset msg2
	call writeString
	call readdec
	mov imageHight , eax
	call crlf
	 @
	;compute elements
	mov elements , eax ; elemets contains the hight
	mov edx , 0
	mov eax , imageWidth
	mul elements
	mov elements , eax
	  comment @
	;get index
	mov edx , offset msg4
	call writeString
	call readdec
	mov index , eax
	call crlf
	@
	;compute nextRow
	mov nextRow , 4
	mov edx , 0
	mul nextRow
	mov nextRow , eax
	
	; compute median
	mov eax , index
	mov edx , 0
	mul eax
	dec eax
	mov ecx , 2
	mul ecx
	mov median , eax

	;get first index
	mov ebx , 2
	mov eax , index
	mov edx , 0
	div ebx         ; eax contains the number of borders
	mov esi , eax   ; edx contains the number of borders
	mov eax , imageWidth
	mov ebx , esi
	mul ebx
	add eax , esi
	mov ebx , 4
	mul ebx
	mov firstIndex , eax

	;compute sumWindow
	mov eax , imageWidth
	sub eax , index
	mov ebx , 4
	mul ebx
	mov sumWindow , eax

ret
computeConst ENDP

;-----------------------------------------------------------------------------;
;	a function that iterates over the array to get the middle of each window  ;
;-----------------------------------------------------------------------------;

getWindow PROC uses eax ebx ecx edx esi edi, image:ptr dword,result:ptr dword
	
	mov ebx ,  image
	add ebx , firstIndex


	mov esi , imageHight    ; will contains the hight - (2* index)
	mov edi , imageWidth	; will contains the width - (2* index)

	sub esi , index
	sub edi , index

	inc esi
	inc edi

	mov ecx , esi

	mov esi , result
	add esi , firstIndex

	outerOne :
	push ecx
	mov ecx , edi
		innerOne :
			call constructArray   ; we will start to construct each window using the center of each one
			push eax
			mov eax , midPixel
			mov [esi] , eax
			pop eax
			add ebx , 4
			add esi , 4
		loop innerOne
	pop ecx
	sub ebx , 4
	sub esi , 4
	add ebx , nextRow
	add esi , nextRow
	loop outerOne	
ret
getWindow ENDP


;---------------------------------------------------------------;
;	a function that get the begining of each center in windows  ;
;		and then put elements in an array to sort it			;
;---------------------------------------------------------------;	

constructArray PROC uses eax ebx ecx edx esi edi
	 ;mov ebx , 132     ; we will remove it as it contains by defaukt the index of the center of the window
	mov eax , index
	mov ecx , 2
	mov edx , 0
	div ecx			 ; eax contains the number of borders
	mov edi , eax	 ; edi contains the number of borders  
	mov esi , imageWidth
	mul esi
	mov esi , 4
	mul esi
	sub ebx , eax
	mov eax , edi
	mov esi , 4
	mul esi
	sub ebx , eax	; eax contains the begining of the window
	
	mov esi , offset window		; array that will contains the window elements to sort it and get the median

	mov ecx , index

	column :
	push ecx
	mov ecx , index
		row :
			mov edi , [ebx]     ; edi is used to move values from 2 memeory values
			mov [esi] , edi
			add esi , 4
			add ebx , 4
		loop row
	pop ecx
	add ebx , sumWindow
	loop column
	
	call bubbleSort
	call getMedian
ret
constructArray ENDP

;------------;
;	 sort    ;
;------------;

bubbleSort PROC uses eax  ecx  esi

mov eax , index
mul index
mov ecx , eax
dec ecx

L1 :
	push ecx
	mov esi , offset window

	L2 :
		mov eax , [esi]
		cmp [esi+4] , eax
		ja L3
		xchg eax , [esi+4]	
		mov [esi] , eax

		L3 : 
			add esi , 4
	loop L2

	pop ecx
Loop L1

L4 : ret

bubbleSort ENDP

;----------------------------------------------------;
;	a function that returns the median of an array	 ;
;----------------------------------------------------;

getMedian PROC uses eax  ebx  ecx edx esi edi
	mov ebx , offset window
	add ebx , median
	mov eax , [ebx]
	mov midPixel , eax
ret
getMedian ENDP



; DllMain is required for any DLL
DllMain PROC hInstance:DWORD, fdwReason:DWORD, lpReserved:DWORD
mov eax, 1 ; Return true to caller.
ret
DllMain ENDP
END DllMain