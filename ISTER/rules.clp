(deftemplate ioproxy ; шаблон факта-посредника для обмена информацией с GUI
	(slot message (default none))
)

(deffacts proxy-fact ; экземпляр факта ioproxy
	(ioproxy
		(message none)
	)
)

(defrule clear-message
	(declare (salience 90))
	?clear-msg-flg <- (clearmessage)
	?sendmessage <- (sendmessagehalt ?msg)
	=>
	(retract ?clear-msg-flg)
	(retract ?sendmessage)
)

(defrule set-output-and-halt
	(declare (salience 99))
	?current-message <- (sendmessagehalt ?new-msg)
	?proxy <- (ioproxy (message ?msg))
	=>
	(modify ?proxy (message ?new-msg))
	(retract ?current-message)
	(halt)
)
(defrule r1 
	(declare  (salience 50) ) 
	( item (id f1) ) 
	=>
	(assert ( item ( id f9) ) )
	(assert ( sendmessagehalt 'Древесина')) 
)

(defrule r2 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	=>
	(assert ( item ( id f12) ) )
	(assert ( sendmessagehalt 'Верстак')) 
)

(defrule r3 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f13) ) )
	(assert ( sendmessagehalt 'Внутренние стены из древесины')) 
)

(defrule r4 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f14) ) )
	(assert ( sendmessagehalt 'Деревянная дверь')) 
)

(defrule r5 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f15) ) )
	(assert ( sendmessagehalt 'Деревянный стол')) 
)

(defrule r6 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f16) ) )
	(assert ( sendmessagehalt 'Деревянный стул')) 
)

(defrule r7 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f17) ) )
	(assert ( sendmessagehalt 'Лук')) 
)

(defrule r8 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	( item (id f10) ) 
	=>
	(assert ( item ( id f18) ) )
	(assert ( sendmessagehalt 'Стрелы')) 
)

(defrule r9 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f24) ) 
	=>
	(assert ( item ( id f25) ) )
	(assert ( sendmessagehalt 'Факел')) 
)

(defrule r10 
	(declare  (salience 50) ) 
	( item (id f6) ) 
	=>
	(assert ( item ( id f20) ) )
	(assert ( sendmessagehalt 'Пиранья')) 
)

(defrule r11 
	(declare  (salience 50) ) 
	( item (id f20) ) 
	=>
	(assert ( item ( id f21) ) )
	(assert ( sendmessagehalt 'Крюк')) 
)

(defrule r12 
	(declare  (salience 50) ) 
	( item (id f6) ) 
	=>
	(assert ( item ( id f7) ) )
	(assert ( sendmessagehalt 'Улей')) 
)

(defrule r13 
	(declare  (salience 50) ) 
	( item (id f13) ) 
	( item (id f14) ) 
	( item (id f15) ) 
	( item (id f16) ) 
	( item (id f25) ) 
	=>
	(assert ( item ( id rf26) ) )
	(assert ( sendmessagehalt 'Комната для NPC')) 
)

(defrule r14 
	(declare  (salience 50) ) 
	( item (id f18) ) 
	( item (id f25) ) 
	=>
	(assert ( item ( id f34) ) )
	(assert ( sendmessagehalt 'Горящие стрелы')) 
)

(defrule r15 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f10) ) 
	( item (id f25) ) 
	=>
	(assert ( item ( id f35) ) )
	(assert ( sendmessagehalt 'Печь')) 
)

(defrule r16 
	(declare  (salience 50) ) 
	( item (id f3) ) 
	=>
	(assert ( item ( id f33) ) )
	(assert ( sendmessagehalt 'Песок')) 
)

(defrule r17 
	(declare  (salience 50) ) 
	( item (id f33) ) 
	( item (id f35) ) 
	=>
	(assert ( item ( id f36) ) )
	(assert ( sendmessagehalt 'Стекло')) 
)

(defrule r18 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f36) ) 
	=>
	(assert ( item ( id f37) ) )
	(assert ( sendmessagehalt 'Бутылка')) 
)

(defrule r19 
	(declare  (salience 50) ) 
	( item (id f3) ) 
	( item (id f37) ) 
	=>
	(assert ( item ( id f38) ) )
	(assert ( sendmessagehalt 'Бутылка с водой')) 
)

(defrule r20 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f37) ) 
	=>
	(assert ( item ( id f39) ) )
	(assert ( sendmessagehalt 'Зельеварка')) 
)

(defrule r21 
	(declare  (salience 50) ) 
	( item (id f28) ) 
	( item (id f37) ) 
	( item (id f39) ) 
	=>
	(assert ( item ( id f40) ) )
	(assert ( sendmessagehalt 'Малое зелье лечения')) 
)

(defrule r22 
	(declare  (salience 50) ) 
	( item (id f24) ) 
	( item (id f27) ) 
	( item (id f37) ) 
	( item (id f39) ) 
	=>
	(assert ( item ( id f41) ) )
	(assert ( sendmessagehalt 'Малое зелье маны')) 
)

(defrule r23 
	(declare  (salience 50) ) 
	( item (id f32) ) 
	( item (id f39) ) 
	( item (id f40) ) 
	=>
	(assert ( item ( id f42) ) )
	(assert ( sendmessagehalt 'Лечебное зелье')) 
)

(defrule r24 
	(declare  (salience 50) ) 
	( item (id f32) ) 
	( item (id f39) ) 
	( item (id f41) ) 
	=>
	(assert ( item ( id f43) ) )
	(assert ( sendmessagehalt 'Зелье маны')) 
)

(defrule r25 
	(declare  (salience 50) ) 
	( item (id f31) ) 
	( item (id f38) ) 
	( item (id f11) ) 
	=>
	(assert ( item ( id f44) ) )
	(assert ( sendmessagehalt 'Зелье железной кожи')) 
)

(defrule r26 
	(declare  (salience 50) ) 
	( item (id f11) ) 
	( item (id f35) ) 
	=>
	(assert ( item ( id f45) ) )
	(assert ( sendmessagehalt 'Железные слитки')) 
)

(defrule r27 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f45) ) 
	=>
	(assert ( item ( id rf46) ) )
	(assert ( sendmessagehalt 'Наковальня')) 
)

(defrule r28 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f47) ) )
	(assert ( sendmessagehalt 'Цепь')) 
)

(defrule r29 
	(declare  (salience 50) ) 
	( item (id f21) ) 
	( item (id f47) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id rf48) ) )
	(assert ( sendmessagehalt 'Крюк-кошка')) 
)

(defrule r30 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f49) ) )
	(assert ( sendmessagehalt 'Железный сет')) 
)

(defrule r31 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f50) ) )
	(assert ( sendmessagehalt 'Железный лук')) 
)

(defrule r32 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f51) ) )
	(assert ( sendmessagehalt 'Железный меч')) 
)

(defrule r33 
	(declare  (salience 50) ) 
	( item (id f17) ) 
	( item (id f18) ) 
	( item (id f53) ) 
	=>
	(assert ( item ( id f54) ) )
	(assert ( sendmessagehalt 'Линзы')) 
)

(defrule r34 
	(declare  (salience 50) ) 
	( item (id f52) ) 
	( item (id f54) ) 
	=>
	(assert ( item ( id f55) ) )
	(assert ( sendmessagehalt 'Глаз призывалка')) 
)

(defrule r35 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f58) ) )
	(assert ( sendmessagehalt 'Сюрикены')) 
)

(defrule r36 
	(declare  (salience 50) ) 
	( item (id f40) ) 
	( item (id f49) ) 
	( item (id f50) ) 
	( item (id f34) ) 
	( item (id f51) ) 
	( item (id f55) ) 
	( item (id f58) ) 
	=>
	(assert ( item ( id rf59) ) )
	(assert ( sendmessagehalt 'Глаз Ктулху')) 
)

(defrule r37 
	(declare  (salience 50) ) 
	( item (id rf59) ) 
	=>
	(assert ( item ( id f60) ) )
	(assert ( sendmessagehalt 'Нечестивые стрелы')) 
)

(defrule r38 
	(declare  (salience 50) ) 
	( item (id rf59) ) 
	=>
	(assert ( item ( id f61) ) )
	(assert ( sendmessagehalt 'Демонитовая руда')) 
)

(defrule r39 
	(declare  (salience 50) ) 
	( item (id f35) ) 
	( item (id f61) ) 
	=>
	(assert ( item ( id f62) ) )
	(assert ( sendmessagehalt 'Демонитовый слиток')) 
)

(defrule r40 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	=>
	(assert ( item ( id f63) ) )
	(assert ( sendmessagehalt 'Топор ночи')) 
)

(defrule r41 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f64) ) )
	(assert ( sendmessagehalt 'Бомбы')) 
)

(defrule r42 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f65) ) )
	(assert ( sendmessagehalt 'Динамит')) 
)

(defrule r43 
	(declare  (salience 50) ) 
	( item (id f2) ) 
	=>
	(assert ( item ( id f66) ) )
	(assert ( sendmessagehalt 'Теневая сфера')) 
)

(defrule r44 
	(declare  (salience 50) ) 
	( item (id f64) ) 
	( item (id f65) ) 
	( item (id f66) ) 
	=>
	(assert ( item ( id f67) ) )
	(assert ( sendmessagehalt 'Мушкет')) 
)

(defrule r45 
	(declare  (salience 50) ) 
	( item (id rf26) ) 
	( item (id f67) ) 
	=>
	(assert ( item ( id f68) ) )
	(assert ( sendmessagehalt 'NPC Оружейник')) 
)

(defrule r46 
	(declare  (salience 50) ) 
	( item (id f68) ) 
	( item (id f23) ) 
	=>
	(assert ( item ( id f69) ) )
	(assert ( sendmessagehalt 'Мини-акула')) 
)

(defrule r47 
	(declare  (salience 50) ) 
	( item (id f68) ) 
	( item (id f23) ) 
	=>
	(assert ( item ( id f70) ) )
	(assert ( sendmessagehalt 'Мушкетные шарики')) 
)

(defrule r48 
	(declare  (salience 50) ) 
	( item (id f63) ) 
	( item (id f44) ) 
	( item (id f40) ) 
	( item (id f49) ) 
	=>
	(assert ( item ( id rf71) ) )
	(assert ( sendmessagehalt 'Пожиратель миров')) 
)

(defrule r49 
	(declare  (salience 50) ) 
	( item (id rf71) ) 
	=>
	(assert ( item ( id f72) ) )
	(assert ( sendmessagehalt 'Теневая чешуя')) 
)

(defrule r50 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	( item (id f72) ) 
	=>
	(assert ( item ( id f73) ) )
	(assert ( sendmessagehalt 'Кошмарный сет')) 
)

(defrule r51 
	(declare  (salience 50) ) 
	( item (id f7) ) 
	( item (id f73) ) 
	( item (id f67) ) 
	( item (id f70) ) 
	( item (id f40) ) 
	( item (id f44) ) 
	=>
	(assert ( item ( id rf74) ) )
	(assert ( sendmessagehalt 'Королева пчел')) 
)

(defrule r52 
	(declare  (salience 50) ) 
	( item (id rf74) ) 
	=>
	(assert ( item ( id f75) ) )
	(assert ( sendmessagehalt 'Пчеломет')) 
)

(defrule r53 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	( item (id f72) ) 
	=>
	(assert ( item ( id f76) ) )
	(assert ( sendmessagehalt 'Кошмарная кирка')) 
)

(defrule r54 
	(declare  (salience 50) ) 
	( item (id f76) ) 
	( item (id f4) ) 
	=>
	(assert ( item ( id f77) ) )
	(assert ( sendmessagehalt 'Обсидиан')) 
)

(defrule r55 
	(declare  (salience 50) ) 
	( item (id f38) ) 
	( item (id f39) ) 
	( item (id f29) ) 
	( item (id f30) ) 
	( item (id f77) ) 
	=>
	(assert ( item ( id f78) ) )
	(assert ( sendmessagehalt 'Зелье обсидиановой кожи')) 
)

(defrule r56 
	(declare  (salience 50) ) 
	( item (id f4) ) 
	=>
	(assert ( item ( id f79) ) )
	(assert ( sendmessagehalt 'Демон вуду')) 
)

(defrule r57 
	(declare  (salience 50) ) 
	( item (id f79) ) 
	( item (id f67) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f80) ) )
	(assert ( sendmessagehalt 'Кукла вуду гида')) 
)

(defrule r58 
	(declare  (salience 50) ) 
	( item (id f78) ) 
	( item (id f76) ) 
	=>
	(assert ( item ( id f81) ) )
	(assert ( sendmessagehalt 'Адская руда')) 
)

(defrule r59 
	(declare  (salience 50) ) 
	( item (id f35) ) 
	( item (id f81) ) 
	=>
	(assert ( item ( id f82) ) )
	(assert ( sendmessagehalt 'Слиток адского камня')) 
)

(defrule r60 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f77) ) 
	( item (id f81) ) 
	=>
	(assert ( item ( id f82) ) )
	(assert ( sendmessagehalt 'Слиток адского камня')) 
)

(defrule r61 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f82) ) 
	=>
	(assert ( item ( id f83) ) )
	(assert ( sendmessagehalt 'Адский сет')) 
)

(defrule r62 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f82) ) 
	=>
	(assert ( item ( id rf84) ) )
	(assert ( sendmessagehalt 'Литая кирка')) 
)

(defrule r63 
	(declare  (salience 50) ) 
	( item (id f22) ) 
	( item (id f83) ) 
	( item (id f69) ) 
	( item (id f70) ) 
	( item (id f42) ) 
	( item (id f44) ) 
	=>
	(assert ( item ( id rf85) ) )
	(assert ( sendmessagehalt 'Скелетрон')) 
)

(defrule r64 
	(declare  (salience 50) ) 
	( item (id rf85) ) 
	( item (id rf26) ) 
	=>
	(assert ( item ( id rf86) ) )
	(assert ( sendmessagehalt 'NPC ДЕД')) 
)

(defrule r65 
	(declare  (salience 50) ) 
	( item (id rf85) ) 
	=>
	(assert ( item ( id f87) ) )
	(assert ( sendmessagehalt 'Данж')) 
)

(defrule r66 
	(declare  (salience 50) ) 
	( item (id f87) ) 
	=>
	(assert ( item ( id f88) ) )
	(assert ( sendmessagehalt 'Слизень данжа')) 
)

(defrule r67 
	(declare  (salience 50) ) 
	( item (id f88) ) 
	( item (id f69) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f89) ) )
	(assert ( sendmessagehalt 'Ключ')) 
)

(defrule r68 
	(declare  (salience 50) ) 
	( item (id f88) ) 
	( item (id f69) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f91) ) )
	(assert ( sendmessagehalt 'Теневой ключ')) 
)

(defrule r69 
	(declare  (salience 50) ) 
	( item (id f87) ) 
	( item (id f89) ) 
	=>
	(assert ( item ( id rf90) ) )
	(assert ( sendmessagehalt 'Сундук данжа')) 
)

(defrule r70 
	(declare  (salience 50) ) 
	( item (id f4) ) 
	( item (id f91) ) 
	( item (id f78) ) 
	=>
	(assert ( item ( id f92) ) )
	(assert ( sendmessagehalt 'Теневой сундук')) 
)

(defrule r71 
	(declare  (salience 50) ) 
	( item (id f92) ) 
	=>
	(assert ( item ( id rf93) ) )
	(assert ( sendmessagehalt 'Кусочек адского торта')) 
)

(defrule r72 
	(declare  (salience 50) ) 
	( item (id f78) ) 
	( item (id f75) ) 
	( item (id f42) ) 
	( item (id f43) ) 
	( item (id f44) ) 
	( item (id f78) ) 
	( item (id f83) ) 
	=>
	(assert ( item ( id rf94) ) )
	(assert ( sendmessagehalt 'Стена плоти')) 
)

(defrule r73 
	(declare  (salience 50) ) 
	( item (id f63) ) 
	( item (id f1) ) 
	=>
	(assert ( item ( id f9) ) )
	(assert ( sendmessagehalt 'Древесина')) 
)

(defrule r74 
	(declare  (salience 50) ) 
	( item (id f1) ) 
	=>
	(assert ( item ( id f19) ) )
	(assert ( sendmessagehalt 'Слизень')) 
)

(defrule r75 
	(declare  (salience 50) ) 
	( item (id f19) ) 
	=>
	(assert ( item ( id f24) ) )
	(assert ( sendmessagehalt 'Гель')) 
)

