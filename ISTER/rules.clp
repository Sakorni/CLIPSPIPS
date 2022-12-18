(deftemplate item
	(slot id)
)

(deftemplate precept
	(slot id)
)

(defrule r1
	(item (id f1))
	=>
	(assert (item (id f9)))
	(assert (precept (id r1)))
)

(defrule r111
	(item (id f9))
	=>
	(assert (item (id f1)))
	(assert (precept (id r111)))
)

(defrule r2
	(item (id f9))
	=>
	(assert (item (id f12)))
	(assert (precept (id r2)))
)

(defrule r3
	(item (id f9))
	(item (id f12))
	=>
	(assert (item (id f13)))
	(assert (precept (id r3)))
)

(defrule r4
	(item (id f9))
	(item (id f12))
	=>
	(assert (item (id f14)))
	(assert (precept (id r4)))
)

(defrule r5
	(item (id f9))
	(item (id f12))
	=>
	(assert (item (id f15)))
	(assert (precept (id r5)))
)

(defrule r6
	(item (id f9))
	(item (id f12))
	=>
	(assert (item (id f16)))
	(assert (precept (id r6)))
)

(defrule r7
	(item (id f9))
	(item (id f12))
	=>
	(assert (item (id f17)))
	(assert (precept (id r7)))
)

(defrule r8
	(item (id f9))
	(item (id f12))
	(item (id f10))
	=>
	(assert (item (id f18)))
	(assert (precept (id r8)))
)

(defrule r9
	(item (id f9))
	(item (id f24))
	=>
	(assert (item (id f25)))
	(assert (precept (id r9)))
)

(defrule r10
	(item (id f6))
	=>
	(assert (item (id f20)))
	(assert (precept (id r10)))
)

(defrule r11
	(item (id f20))
	=>
	(assert (item (id f21)))
	(assert (precept (id r11)))
)

(defrule r12
	(item (id f6))
	=>
	(assert (item (id f7)))
	(assert (precept (id r12)))
)

(defrule r13
	(item (id f13))
	(item (id f14))
	(item (id f15))
	(item (id f16))
	(item (id f25))
	=>
	(assert (item (id rf26)))
	(assert (precept (id r13)))
)

(defrule r14
	(item (id f18))
	(item (id f25))
	=>
	(assert (item (id f34)))
	(assert (precept (id r14)))
)

(defrule r15
	(item (id f9))
	(item (id f10))
	(item (id f25))
	=>
	(assert (item (id f35)))
	(assert (precept (id r15)))
)

(defrule r16
	(item (id f3))
	=>
	(assert (item (id f33)))
	(assert (precept (id r16)))
)

(defrule r17
	(item (id f33))
	(item (id f35))
	=>
	(assert (item (id f36)))
	(assert (precept (id r17)))
)

(defrule r18
	(item (id f12))
	(item (id f36))
	=>
	(assert (item (id f37)))
	(assert (precept (id r18)))
)

(defrule r19
	(item (id f3))
	(item (id f37))
	=>
	(assert (item (id f38)))
	(assert (precept (id r19)))
)

(defrule r20
	(item (id f12))
	(item (id f37))
	=>
	(assert (item (id f39)))
	(assert (precept (id r20)))
)

(defrule r21
	(item (id f28))
	(item (id f37))
	(item (id f39))
	=>
	(assert (item (id f40)))
	(assert (precept (id r21)))
)

(defrule r22
	(item (id f24))
	(item (id f27))
	(item (id f37))
	(item (id f39))
	=>
	(assert (item (id f41)))
	(assert (precept (id r22)))
)

(defrule r23
	(item (id f32))
	(item (id f39))
	(item (id f40))
	=>
	(assert (item (id f42)))
	(assert (precept (id r23)))
)

(defrule r24
	(item (id f32))
	(item (id f39))
	(item (id f41))
	=>
	(assert (item (id f43)))
	(assert (precept (id r24)))
)

(defrule r25
	(item (id f31))
	(item (id f38))
	(item (id f11))
	=>
	(assert (item (id f44)))
	(assert (precept (id r25)))
)

(defrule r26
	(item (id f11))
	(item (id f35))
	=>
	(assert (item (id f45)))
	(assert (precept (id r26)))
)

(defrule r27
	(item (id f12))
	(item (id f45))
	=>
	(assert (item (id rf46)))
	(assert (precept (id r27)))
)

(defrule r28
	(item (id f45))
	(item (id rf46))
	=>
	(assert (item (id f47)))
	(assert (precept (id r28)))
)

(defrule r29
	(item (id f21))
	(item (id f47))
	(item (id rf46))
	=>
	(assert (item (id rf48)))
	(assert (precept (id r29)))
)

(defrule r30
	(item (id f45))
	(item (id rf46))
	=>
	(assert (item (id f49)))
	(assert (precept (id r30)))
)

(defrule r31
	(item (id f45))
	(item (id rf46))
	=>
	(assert (item (id f50)))
	(assert (precept (id r31)))
)

(defrule r32
	(item (id f45))
	(item (id rf46))
	=>
	(assert (item (id f51)))
	(assert (precept (id r32)))
)

(defrule r33
	(item (id f17))
	(item (id f18))
	(item (id f53))
	=>
	(assert (item (id f54)))
	(assert (precept (id r33)))
)

(defrule r34
	(item (id f52))
	(item (id f54))
	=>
	(assert (item (id f55)))
	(assert (precept (id r34)))
)

(defrule r35
	(item (id f56))
	(item (id f57))
	=>
	(assert (item (id f58)))
	(assert (precept (id r35)))
)

(defrule r36
	(item (id f40))
	(item (id f49))
	(item (id f50))
	(item (id f34))
	(item (id f51))
	(item (id f55))
	(item (id f58))
	=>
	(assert (item (id rf59)))
	(assert (precept (id r36)))
)

(defrule r37
	(item (id rf59))
	=>
	(assert (item (id f60)))
	(assert (precept (id r37)))
)

(defrule r38
	(item (id rf59))
	=>
	(assert (item (id f61)))
	(assert (precept (id r38)))
)

(defrule r39
	(item (id f35))
	(item (id f61))
	=>
	(assert (item (id f62)))
	(assert (precept (id r39)))
)

(defrule r40
	(item (id rf46))
	(item (id f62))
	=>
	(assert (item (id f63)))
	(assert (precept (id r40)))
)

(defrule r41
	(item (id f56))
	(item (id f57))
	=>
	(assert (item (id f64)))
	(assert (precept (id r41)))
)

(defrule r42
	(item (id f56))
	(item (id f57))
	=>
	(assert (item (id f65)))
	(assert (precept (id r42)))
)

(defrule r43
	(item (id f2))
	=>
	(assert (item (id f66)))
	(assert (precept (id r43)))
)

(defrule r44
	(item (id f64))
	(item (id f65))
	(item (id f66))
	=>
	(assert (item (id f67)))
	(assert (precept (id r44)))
)

(defrule r45
	(item (id rf26))
	(item (id f67))
	=>
	(assert (item (id f68)))
	(assert (precept (id r45)))
)

(defrule r46
	(item (id f68))
	(item (id f23))
	=>
	(assert (item (id f69)))
	(assert (precept (id r46)))
)

(defrule r47
	(item (id f68))
	(item (id f23))
	=>
	(assert (item (id f70)))
	(assert (precept (id r47)))
)

(defrule r48
	(item (id f63))
	(item (id f44))
	(item (id f40))
	(item (id f49))
	=>
	(assert (item (id rf71)))
	(assert (precept (id r48)))
)

(defrule r49
	(item (id rf71))
	=>
	(assert (item (id f72)))
	(assert (precept (id r49)))
)

(defrule r50
	(item (id rf46))
	(item (id f62))
	(item (id f72))
	=>
	(assert (item (id f73)))
	(assert (precept (id r50)))
)

(defrule r51
	(item (id f7))
	(item (id f73))
	(item (id f67))
	(item (id f70))
	(item (id f40))
	(item (id f44))
	=>
	(assert (item (id rf74)))
	(assert (precept (id r51)))
)

(defrule r52
	(item (id rf74))
	=>
	(assert (item (id f75)))
	(assert (precept (id r52)))
)

(defrule r53
	(item (id rf46))
	(item (id f62))
	(item (id f72))
	=>
	(assert (item (id f76)))
	(assert (precept (id r53)))
)

(defrule r54
	(item (id f76))
	(item (id f4))
	=>
	(assert (item (id f77)))
	(assert (precept (id r54)))
)

(defrule r55
	(item (id f38))
	(item (id f39))
	(item (id f29))
	(item (id f30))
	(item (id f77))
	=>
	(assert (item (id f78)))
	(assert (precept (id r55)))
)

(defrule r56
	(item (id f4))
	=>
	(assert (item (id f79)))
	(assert (precept (id r56)))
)

(defrule r57
	(item (id f79))
	(item (id f67))
	(item (id f70))
	=>
	(assert (item (id f80)))
	(assert (precept (id r57)))
)

(defrule r58
	(item (id f78))
	(item (id f76))
	=>
	(assert (item (id f81)))
	(assert (precept (id r58)))
)

(defrule r59
	(item (id f35))
	(item (id f81))
	=>
	(assert (item (id f82)))
	(assert (precept (id r59)))
)

(defrule r60
	(item (id rf46))
	(item (id f77))
	(item (id f81))
	=>
	(assert (item (id f82)))
	(assert (precept (id r60)))
)

(defrule r61
	(item (id rf46))
	(item (id f82))
	=>
	(assert (item (id f83)))
	(assert (precept (id r61)))
)

(defrule r62
	(item (id rf46))
	(item (id f82))
	=>
	(assert (item (id rf84)))
	(assert (precept (id r62)))
)

(defrule r63
	(item (id f22))
	(item (id f83))
	(item (id f69))
	(item (id f70))
	(item (id f42))
	(item (id f44))
	=>
	(assert (item (id rf85)))
	(assert (precept (id r63)))
)

(defrule r64
	(item (id rf85))
	(item (id rf26))
	=>
	(assert (item (id rf86)))
	(assert (precept (id r64)))
)

(defrule r65
	(item (id rf85))
	=>
	(assert (item (id f87)))
	(assert (precept (id r65)))
)

(defrule r66
	(item (id f87))
	=>
	(assert (item (id f88)))
	(assert (precept (id r66)))
)

(defrule r67
	(item (id f88))
	(item (id f69))
	(item (id f70))
	=>
	(assert (item (id f89)))
	(assert (precept (id r67)))
)

(defrule r68
	(item (id f88))
	(item (id f69))
	(item (id f70))
	=>
	(assert (item (id f91)))
	(assert (precept (id r68)))
)

(defrule r69
	(item (id f87))
	(item (id f89))
	=>
	(assert (item (id rf90)))
	(assert (precept (id r69)))
)

(defrule r70
	(item (id f4))
	(item (id f91))
	(item (id f78))
	=>
	(assert (item (id f92)))
	(assert (precept (id r70)))
)

(defrule r71
	(item (id f92))
	=>
	(assert (item (id rf93)))
	(assert (precept (id r71)))
)

(defrule r72
	(item (id f78))
	(item (id f75))
	(item (id f42))
	(item (id f43))
	(item (id f44))
	(item (id f78))
	(item (id f83))
	=>
	(assert (item (id rf94)))
	(assert (precept (id r72)))
)

(defrule r73
	(item (id f63))
	(item (id f1))
	=>
	(assert (item (id f9)))
	(assert (precept (id r73)))
)

(defrule r74
	(item (id f1))
	=>
	(assert (item (id f19)))
	(assert (precept (id r74)))
)

(defrule r75
	(item (id f19))
	=>
	(assert (item (id f24)))
	(assert (precept (id r75)))
)

