
(deftemplate item
    (slot is)
    (slot id)
	(slot priority)
)
(deffacts items 
(item (is 0) (id f1) (priority 1))
(item (is 0) (id f2) (priority 1))
(item (is 0) (id f3) (priority 1))
(item (is 0) (id f4) (priority 1))
(item (is 0) (id f5) (priority 1))
(item (is 0) (id f6) (priority 1))
(item (is 0) (id f7) (priority 1))
(item (is 0) (id f8) (priority 1))
(item (is 0) (id f9) (priority 1))
(item (is 0) (id f10) (priority 1))
(item (is 0) (id f11) (priority 1))
(item (is 0) (id f12) (priority 1))
(item (is 0) (id f13) (priority 1))
(item (is 0) (id f14) (priority 1))
(item (is 0) (id f15) (priority 1))
(item (is 0) (id f16) (priority 1))
(item (is 0) (id f17) (priority 1))
(item (is 0) (id f18) (priority 1))
(item (is 0) (id f19) (priority 1))
(item (is 0) (id f20) (priority 1))
(item (is 0) (id f21) (priority 1))
(item (is 0) (id f22) (priority 1))
(item (is 0) (id f23) (priority 1))
(item (is 0) (id f24) (priority 1))
(item (is 0) (id f25) (priority 1))
(item (is 0) (id rf26) (priority 1))
(item (is 0) (id f27) (priority 1))
(item (is 0) (id f28) (priority 1))
(item (is 0) (id f29) (priority 1))
(item (is 0) (id f30) (priority 1))
(item (is 0) (id f31) (priority 1))
(item (is 0) (id f32) (priority 1))
(item (is 0) (id f33) (priority 1))
(item (is 0) (id f34) (priority 1))
(item (is 0) (id f35) (priority 1))
(item (is 0) (id f36) (priority 1))
(item (is 0) (id f37) (priority 1))
(item (is 0) (id f38) (priority 1))
(item (is 0) (id f39) (priority 1))
(item (is 0) (id f40) (priority 1))
(item (is 0) (id f41) (priority 1))
(item (is 0) (id f42) (priority 1))
(item (is 0) (id f43) (priority 1))
(item (is 0) (id f44) (priority 1))
(item (is 0) (id f45) (priority 1))
(item (is 0) (id rf46) (priority 1))
(item (is 0) (id f47) (priority 1))
(item (is 0) (id rf48) (priority 1))
(item (is 0) (id f49) (priority 1))
(item (is 0) (id f50) (priority 1))
(item (is 0) (id f51) (priority 1))
(item (is 0) (id f52) (priority 1))
(item (is 0) (id f53) (priority 1))
(item (is 0) (id f54) (priority 1))
(item (is 0) (id f55) (priority 1))
(item (is 0) (id f56) (priority 1))
(item (is 0) (id f57) (priority 1))
(item (is 0) (id f58) (priority 1))
(item (is 0) (id rf59) (priority 1))
(item (is 0) (id f60) (priority 1))
(item (is 0) (id f61) (priority 1))
(item (is 0) (id f62) (priority 1))
(item (is 0) (id f63) (priority 1))
(item (is 0) (id f64) (priority 1))
(item (is 0) (id f65) (priority 1))
(item (is 0) (id f66) (priority 1))
(item (is 0) (id f67) (priority 1))
(item (is 0) (id f68) (priority 1))
(item (is 0) (id f69) (priority 1))
(item (is 0) (id f70) (priority 1))
(item (is 0) (id rf71) (priority 1))
(item (is 0) (id f72) (priority 1))
(item (is 0) (id f73) (priority 1))
(item (is 0) (id rf74) (priority 1))
(item (is 0) (id f75) (priority 1))
(item (is 0) (id f76) (priority 1))
(item (is 0) (id f77) (priority 1))
(item (is 0) (id f78) (priority 1))
(item (is 0) (id f79) (priority 1))
(item (is 0) (id f80) (priority 1))
(item (is 0) (id f81) (priority 1))
(item (is 0) (id f82) (priority 1))
(item (is 0) (id f83) (priority 1))
(item (is 0) (id rf84) (priority 1))
(item (is 0) (id rf85) (priority 1))
(item (is 0) (id rf86) (priority 1))
(item (is 0) (id f87) (priority 1))
(item (is 0) (id f88) (priority 1))
(item (is 0) (id f89) (priority 1))
(item (is 0) (id rf90) (priority 1))
(item (is 0) (id f91) (priority 1))
(item (is 0) (id f92) (priority 1))
(item (is 0) (id rf93) (priority 1))
(item (is 0) (id rf94) (priority 1))
)
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
	(halt)
	=>
	(retract ?clear-msg-flg)
	(retract ?sendmessage)
)

(defrule set-output-and-halt
	(declare (salience 99))
	?current-message <- (sendmessagehalt ?new-msg)
	(halt)
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
	(halt)
)

(defrule r2 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	=>
	(assert ( item ( id f12) ) )
	(assert ( sendmessagehalt 'Верстак')) 
	(halt)
)

(defrule r3 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f13) ) )
	(assert ( sendmessagehalt 'Внутренние стены из древесины')) 
	(halt)
)

(defrule r4 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f14) ) )
	(assert ( sendmessagehalt 'Деревянная дверь')) 
	(halt)
)

(defrule r5 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f15) ) )
	(assert ( sendmessagehalt 'Деревянный стол')) 
	(halt)
)

(defrule r6 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f16) ) )
	(assert ( sendmessagehalt 'Деревянный стул')) 
	(halt)
)

(defrule r7 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	=>
	(assert ( item ( id f17) ) )
	(assert ( sendmessagehalt 'Лук')) 
	(halt)
)

(defrule r8 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f12) ) 
	( item (id f10) ) 
	=>
	(assert ( item ( id f18) ) )
	(assert ( sendmessagehalt 'Стрелы')) 
	(halt)
)

(defrule r9 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f24) ) 
	=>
	(assert ( item ( id f25) ) )
	(assert ( sendmessagehalt 'Факел')) 
	(halt)
)

(defrule r10 
	(declare  (salience 50) ) 
	( item (id f6) ) 
	=>
	(assert ( item ( id f20) ) )
	(assert ( sendmessagehalt 'Пиранья')) 
	(halt)
)

(defrule r11 
	(declare  (salience 50) ) 
	( item (id f20) ) 
	=>
	(assert ( item ( id f21) ) )
	(assert ( sendmessagehalt 'Крюк')) 
	(halt)
)

(defrule r12 
	(declare  (salience 50) ) 
	( item (id f6) ) 
	=>
	(assert ( item ( id f7) ) )
	(assert ( sendmessagehalt 'Улей')) 
	(halt)
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
	(halt)
)

(defrule r14 
	(declare  (salience 50) ) 
	( item (id f18) ) 
	( item (id f25) ) 
	=>
	(assert ( item ( id f34) ) )
	(assert ( sendmessagehalt 'Горящие стрелы')) 
	(halt)
)

(defrule r15 
	(declare  (salience 50) ) 
	( item (id f9) ) 
	( item (id f10) ) 
	( item (id f25) ) 
	=>
	(assert ( item ( id f35) ) )
	(assert ( sendmessagehalt 'Печь')) 
	(halt)
)

(defrule r16 
	(declare  (salience 50) ) 
	( item (id f3) ) 
	=>
	(assert ( item ( id f33) ) )
	(assert ( sendmessagehalt 'Песок')) 
	(halt)
)

(defrule r17 
	(declare  (salience 50) ) 
	( item (id f33) ) 
	( item (id f35) ) 
	=>
	(assert ( item ( id f36) ) )
	(assert ( sendmessagehalt 'Стекло')) 
	(halt)
)

(defrule r18 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f36) ) 
	=>
	(assert ( item ( id f37) ) )
	(assert ( sendmessagehalt 'Бутылка')) 
	(halt)
)

(defrule r19 
	(declare  (salience 50) ) 
	( item (id f3) ) 
	( item (id f37) ) 
	=>
	(assert ( item ( id f38) ) )
	(assert ( sendmessagehalt 'Бутылка с водой')) 
	(halt)
)

(defrule r20 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f37) ) 
	=>
	(assert ( item ( id f39) ) )
	(assert ( sendmessagehalt 'Зельеварка')) 
	(halt)
)

(defrule r21 
	(declare  (salience 50) ) 
	( item (id f28) ) 
	( item (id f37) ) 
	( item (id f39) ) 
	=>
	(assert ( item ( id f40) ) )
	(assert ( sendmessagehalt 'Малое зелье лечения')) 
	(halt)
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
	(halt)
)

(defrule r23 
	(declare  (salience 50) ) 
	( item (id f32) ) 
	( item (id f39) ) 
	( item (id f40) ) 
	=>
	(assert ( item ( id f42) ) )
	(assert ( sendmessagehalt 'Лечебное зелье')) 
	(halt)
)

(defrule r24 
	(declare  (salience 50) ) 
	( item (id f32) ) 
	( item (id f39) ) 
	( item (id f41) ) 
	=>
	(assert ( item ( id f43) ) )
	(assert ( sendmessagehalt 'Зелье маны')) 
	(halt)
)

(defrule r25 
	(declare  (salience 50) ) 
	( item (id f31) ) 
	( item (id f38) ) 
	( item (id f11) ) 
	=>
	(assert ( item ( id f44) ) )
	(assert ( sendmessagehalt 'Зелье железной кожи')) 
	(halt)
)

(defrule r26 
	(declare  (salience 50) ) 
	( item (id f11) ) 
	( item (id f35) ) 
	=>
	(assert ( item ( id f45) ) )
	(assert ( sendmessagehalt 'Железные слитки')) 
	(halt)
)

(defrule r27 
	(declare  (salience 50) ) 
	( item (id f12) ) 
	( item (id f45) ) 
	=>
	(assert ( item ( id rf46) ) )
	(assert ( sendmessagehalt 'Наковальня')) 
	(halt)
)

(defrule r28 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f47) ) )
	(assert ( sendmessagehalt 'Цепь')) 
	(halt)
)

(defrule r29 
	(declare  (salience 50) ) 
	( item (id f21) ) 
	( item (id f47) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id rf48) ) )
	(assert ( sendmessagehalt 'Крюк-кошка')) 
	(halt)
)

(defrule r30 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f49) ) )
	(assert ( sendmessagehalt 'Железный сет')) 
	(halt)
)

(defrule r31 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f50) ) )
	(assert ( sendmessagehalt 'Железный лук')) 
	(halt)
)

(defrule r32 
	(declare  (salience 50) ) 
	( item (id f45) ) 
	( item (id rf46) ) 
	=>
	(assert ( item ( id f51) ) )
	(assert ( sendmessagehalt 'Железный меч')) 
	(halt)
)

(defrule r33 
	(declare  (salience 50) ) 
	( item (id f17) ) 
	( item (id f18) ) 
	( item (id f53) ) 
	=>
	(assert ( item ( id f54) ) )
	(assert ( sendmessagehalt 'Линзы')) 
	(halt)
)

(defrule r34 
	(declare  (salience 50) ) 
	( item (id f52) ) 
	( item (id f54) ) 
	=>
	(assert ( item ( id f55) ) )
	(assert ( sendmessagehalt 'Глаз призывалка')) 
	(halt)
)

(defrule r35 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f58) ) )
	(assert ( sendmessagehalt 'Сюрикены')) 
	(halt)
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
	(halt)
)

(defrule r37 
	(declare  (salience 50) ) 
	( item (id rf59) ) 
	=>
	(assert ( item ( id f60) ) )
	(assert ( sendmessagehalt 'Нечестивые стрелы')) 
	(halt)
)

(defrule r38 
	(declare  (salience 50) ) 
	( item (id rf59) ) 
	=>
	(assert ( item ( id f61) ) )
	(assert ( sendmessagehalt 'Демонитовая руда')) 
	(halt)
)

(defrule r39 
	(declare  (salience 50) ) 
	( item (id f35) ) 
	( item (id f61) ) 
	=>
	(assert ( item ( id f62) ) )
	(assert ( sendmessagehalt 'Демонитовый слиток')) 
	(halt)
)

(defrule r40 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	=>
	(assert ( item ( id f63) ) )
	(assert ( sendmessagehalt 'Топор ночи')) 
	(halt)
)

(defrule r41 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f64) ) )
	(assert ( sendmessagehalt 'Бомбы')) 
	(halt)
)

(defrule r42 
	(declare  (salience 50) ) 
	( item (id f56) ) 
	( item (id f57) ) 
	=>
	(assert ( item ( id f65) ) )
	(assert ( sendmessagehalt 'Динамит')) 
	(halt)
)

(defrule r43 
	(declare  (salience 50) ) 
	( item (id f2) ) 
	=>
	(assert ( item ( id f66) ) )
	(assert ( sendmessagehalt 'Теневая сфера')) 
	(halt)
)

(defrule r44 
	(declare  (salience 50) ) 
	( item (id f64) ) 
	( item (id f65) ) 
	( item (id f66) ) 
	=>
	(assert ( item ( id f67) ) )
	(assert ( sendmessagehalt 'Мушкет')) 
	(halt)
)

(defrule r45 
	(declare  (salience 50) ) 
	( item (id rf26) ) 
	( item (id f67) ) 
	=>
	(assert ( item ( id f68) ) )
	(assert ( sendmessagehalt 'NPC Оружейник')) 
	(halt)
)

(defrule r46 
	(declare  (salience 50) ) 
	( item (id f68) ) 
	( item (id f23) ) 
	=>
	(assert ( item ( id f69) ) )
	(assert ( sendmessagehalt 'Мини-акула')) 
	(halt)
)

(defrule r47 
	(declare  (salience 50) ) 
	( item (id f68) ) 
	( item (id f23) ) 
	=>
	(assert ( item ( id f70) ) )
	(assert ( sendmessagehalt 'Мушкетные шарики')) 
	(halt)
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
	(halt)
)

(defrule r49 
	(declare  (salience 50) ) 
	( item (id rf71) ) 
	=>
	(assert ( item ( id f72) ) )
	(assert ( sendmessagehalt 'Теневая чешуя')) 
	(halt)
)

(defrule r50 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	( item (id f72) ) 
	=>
	(assert ( item ( id f73) ) )
	(assert ( sendmessagehalt 'Кошмарный сет')) 
	(halt)
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
	(halt)
)

(defrule r52 
	(declare  (salience 50) ) 
	( item (id rf74) ) 
	=>
	(assert ( item ( id f75) ) )
	(assert ( sendmessagehalt 'Пчеломет')) 
	(halt)
)

(defrule r53 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f62) ) 
	( item (id f72) ) 
	=>
	(assert ( item ( id f76) ) )
	(assert ( sendmessagehalt 'Кошмарная кирка')) 
	(halt)
)

(defrule r54 
	(declare  (salience 50) ) 
	( item (id f76) ) 
	( item (id f4) ) 
	=>
	(assert ( item ( id f77) ) )
	(assert ( sendmessagehalt 'Обсидиан')) 
	(halt)
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
	(halt)
)

(defrule r56 
	(declare  (salience 50) ) 
	( item (id f4) ) 
	=>
	(assert ( item ( id f79) ) )
	(assert ( sendmessagehalt 'Демон вуду')) 
	(halt)
)

(defrule r57 
	(declare  (salience 50) ) 
	( item (id f79) ) 
	( item (id f67) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f80) ) )
	(assert ( sendmessagehalt 'Кукла вуду гида')) 
	(halt)
)

(defrule r58 
	(declare  (salience 50) ) 
	( item (id f78) ) 
	( item (id f76) ) 
	=>
	(assert ( item ( id f81) ) )
	(assert ( sendmessagehalt 'Адская руда')) 
	(halt)
)

(defrule r59 
	(declare  (salience 50) ) 
	( item (id f35) ) 
	( item (id f81) ) 
	=>
	(assert ( item ( id f82) ) )
	(assert ( sendmessagehalt 'Слиток адского камня')) 
	(halt)
)

(defrule r60 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f77) ) 
	( item (id f81) ) 
	=>
	(assert ( item ( id f82) ) )
	(assert ( sendmessagehalt 'Слиток адского камня')) 
	(halt)
)

(defrule r61 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f82) ) 
	=>
	(assert ( item ( id f83) ) )
	(assert ( sendmessagehalt 'Адский сет')) 
	(halt)
)

(defrule r62 
	(declare  (salience 50) ) 
	( item (id rf46) ) 
	( item (id f82) ) 
	=>
	(assert ( item ( id rf84) ) )
	(assert ( sendmessagehalt 'Литая кирка')) 
	(halt)
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
	(halt)
)

(defrule r64 
	(declare  (salience 50) ) 
	( item (id rf85) ) 
	( item (id rf26) ) 
	=>
	(assert ( item ( id rf86) ) )
	(assert ( sendmessagehalt 'NPC ДЕД')) 
	(halt)
)

(defrule r65 
	(declare  (salience 50) ) 
	( item (id rf85) ) 
	=>
	(assert ( item ( id f87) ) )
	(assert ( sendmessagehalt 'Данж')) 
	(halt)
)

(defrule r66 
	(declare  (salience 50) ) 
	( item (id f87) ) 
	=>
	(assert ( item ( id f88) ) )
	(assert ( sendmessagehalt 'Слизень данжа')) 
	(halt)
)

(defrule r67 
	(declare  (salience 50) ) 
	( item (id f88) ) 
	( item (id f69) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f89) ) )
	(assert ( sendmessagehalt 'Ключ')) 
	(halt)
)

(defrule r68 
	(declare  (salience 50) ) 
	( item (id f88) ) 
	( item (id f69) ) 
	( item (id f70) ) 
	=>
	(assert ( item ( id f91) ) )
	(assert ( sendmessagehalt 'Теневой ключ')) 
	(halt)
)

(defrule r69 
	(declare  (salience 50) ) 
	( item (id f87) ) 
	( item (id f89) ) 
	=>
	(assert ( item ( id rf90) ) )
	(assert ( sendmessagehalt 'Сундук данжа')) 
	(halt)
)

(defrule r70 
	(declare  (salience 50) ) 
	( item (id f4) ) 
	( item (id f91) ) 
	( item (id f78) ) 
	=>
	(assert ( item ( id f92) ) )
	(assert ( sendmessagehalt 'Теневой сундук')) 
	(halt)
)

(defrule r71 
	(declare  (salience 50) ) 
	( item (id f92) ) 
	=>
	(assert ( item ( id rf93) ) )
	(assert ( sendmessagehalt 'Кусочек адского торта')) 
	(halt)
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
	(halt)
)

(defrule r73 
	(declare  (salience 50) ) 
	( item (id f63) ) 
	( item (id f1) ) 
	=>
	(assert ( item ( id f9) ) )
	(assert ( sendmessagehalt 'Древесина')) 
	(halt)
)

(defrule r74 
	(declare  (salience 50) ) 
	( item (id f1) ) 
	=>
	(assert ( item ( id f19) ) )
	(assert ( sendmessagehalt 'Слизень')) 
	(halt)
)

(defrule r75 
	(declare  (salience 50) ) 
	( item (id f19) ) 
	=>
	(assert ( item ( id f24) ) )
	(assert ( sendmessagehalt 'Гель')) 
	(halt)
)

