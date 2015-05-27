
#define HSE_VALUE ((uint32_t)8000000) /* STM32 discovery uses a 8Mhz external crystal */


#include "main.h"

volatile uint32_t ticker, downTicker;

/*
 * The USB data must be 4 byte aligned if DMA is enabled. This macro handles
 * the alignment, if necessary (it's actually magic, but don't tell anyone).
 */



void init();
void ColorfulRingOfDeath(void);

/*
 * Define prototypes for interrupt handlers here. The conditional "extern"
 * ensures the weak declarations from startup_stm32f4xx.c are overridden.
 */
#ifdef __cplusplus
 extern "C" {
#endif

void SysTick_Handler(void);
void NMI_Handler(void);
void HardFault_Handler(void);
void MemManage_Handler(void);
void BusFault_Handler(void);
void UsageFault_Handler(void);
void SVC_Handler(void);
void DebugMon_Handler(void);
void PendSV_Handler(void);
void OTG_FS_IRQHandler(void);
void OTG_FS_WKUP_IRQHandler(void);

#ifdef __cplusplus
}
#endif



int main(void)
{
	/* Set up the system clocks */
	SystemInit();

	/* Initialize USB, IO, SysTick, and all those other things you do in the morning */
	init();


	SystemCoreClockUpdate(); // inicjalizacja dystrybucji czasu procesora

	    RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOA, ENABLE);//timer to button

	    /* Enable the SPI periph */
	    RCC_APB2PeriphClockCmd(LIS302DL_SPI_CLK, ENABLE);

	    /* Enable SCK, MOSI and MISO GPIO clocks */
	    RCC_AHB1PeriphClockCmd(LIS302DL_SPI_SCK_GPIO_CLK | LIS302DL_SPI_MISO_GPIO_CLK | LIS302DL_SPI_MOSI_GPIO_CLK, ENABLE);

	    /* Enable CS  GPIO clock */
	    RCC_AHB1PeriphClockCmd(LIS302DL_SPI_CS_GPIO_CLK, ENABLE);

	    /* Enable INT1 GPIO clock */
	    RCC_AHB1PeriphClockCmd(LIS302DL_SPI_INT1_GPIO_CLK, ENABLE);

	    /* Enable INT2 GPIO clock */
	    RCC_AHB1PeriphClockCmd(LIS302DL_SPI_INT2_GPIO_CLK, ENABLE);

	    GPIO_PinAFConfig(LIS302DL_SPI_SCK_GPIO_PORT, LIS302DL_SPI_SCK_SOURCE, LIS302DL_SPI_SCK_AF);
	    GPIO_PinAFConfig(LIS302DL_SPI_MISO_GPIO_PORT, LIS302DL_SPI_MISO_SOURCE, LIS302DL_SPI_MISO_AF);
	    GPIO_PinAFConfig(LIS302DL_SPI_MOSI_GPIO_PORT, LIS302DL_SPI_MOSI_SOURCE, LIS302DL_SPI_MOSI_AF);

	    GPIO_InitTypeDef GPIO_InitStructure;
	    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_AF;
	    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	    GPIO_InitStructure.GPIO_PuPd  = GPIO_PuPd_DOWN;
	    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;

	    /* SPI SCK pin configuration */
	    GPIO_InitStructure.GPIO_Pin = LIS302DL_SPI_SCK_PIN;
	    GPIO_Init(LIS302DL_SPI_SCK_GPIO_PORT, &GPIO_InitStructure);

	    /* SPI  MOSI pin configuration */
	    GPIO_InitStructure.GPIO_Pin =  LIS302DL_SPI_MOSI_PIN;
	    GPIO_Init(LIS302DL_SPI_MOSI_GPIO_PORT, &GPIO_InitStructure);

	    /* SPI MISO pin configuration */
	    GPIO_InitStructure.GPIO_Pin = LIS302DL_SPI_MISO_PIN;
	    GPIO_Init(LIS302DL_SPI_MISO_GPIO_PORT, &GPIO_InitStructure);

	    /* SPI configuration -------------------------------------------------------*/
	    SPI_InitTypeDef  SPI_InitStructure;
	    SPI_I2S_DeInit(LIS302DL_SPI);
	    SPI_InitStructure.SPI_Direction = SPI_Direction_2Lines_FullDuplex;
	    SPI_InitStructure.SPI_DataSize = SPI_DataSize_8b;
	    SPI_InitStructure.SPI_CPOL = SPI_CPOL_Low;
	    SPI_InitStructure.SPI_CPHA = SPI_CPHA_1Edge;
	    SPI_InitStructure.SPI_NSS = SPI_NSS_Soft;
	    SPI_InitStructure.SPI_BaudRatePrescaler = SPI_BaudRatePrescaler_4;
	    SPI_InitStructure.SPI_FirstBit = SPI_FirstBit_MSB;
	    SPI_InitStructure.SPI_CRCPolynomial = 7;
	    SPI_InitStructure.SPI_Mode = SPI_Mode_Master;
	    SPI_Init(LIS302DL_SPI, &SPI_InitStructure);

	    /* Enable SPI1  */
	    SPI_Cmd(LIS302DL_SPI, ENABLE);

	    /* Configure GPIO PIN for Lis Chip select */
	    GPIO_InitStructure.GPIO_Pin = LIS302DL_SPI_CS_PIN;
	    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_OUT;
	    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	    GPIO_Init(LIS302DL_SPI_CS_GPIO_PORT, &GPIO_InitStructure);

	    /* Deselect : Chip Select high */
	    GPIO_SetBits(LIS302DL_SPI_CS_GPIO_PORT, LIS302DL_SPI_CS_PIN);

	    /* Configure GPIO PINs to detect Interrupts */
	    GPIO_InitStructure.GPIO_Pin = LIS302DL_SPI_INT1_PIN;
	    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	    GPIO_InitStructure.GPIO_OType = GPIO_OType_PP;
	    GPIO_InitStructure.GPIO_Speed = GPIO_Speed_50MHz;
	    GPIO_InitStructure.GPIO_PuPd  = GPIO_PuPd_NOPULL;
	    GPIO_Init(LIS302DL_SPI_INT1_GPIO_PORT, &GPIO_InitStructure);

	    GPIO_InitStructure.GPIO_Pin = LIS302DL_SPI_INT2_PIN;
	    GPIO_Init(LIS302DL_SPI_INT2_GPIO_PORT, &GPIO_InitStructure);


	    LIS302DL_InitTypeDef  LIS302DL_InitStruct;
	  //  uint8_t ctrl = 0x00;

	    /* Set configuration of LIS302DL*/
	    LIS302DL_InitStruct.Power_Mode = LIS302DL_LOWPOWERMODE_ACTIVE;
	    LIS302DL_InitStruct.Output_DataRate = LIS302DL_DATARATE_100;
	    LIS302DL_InitStruct.Axes_Enable = LIS302DL_X_ENABLE | LIS302DL_Y_ENABLE | LIS302DL_Z_ENABLE;
	    LIS302DL_InitStruct.Full_Scale = LIS302DL_FULLSCALE_2_3;
	    LIS302DL_InitStruct.Self_Test = LIS302DL_SELFTEST_NORMAL;
	    LIS302DL_Init(&LIS302DL_InitStruct);

	    LIS302DL_InterruptConfigTypeDef LIS302DL_InterruptStruct;
	    /* Set configuration of Internal High Pass Filter of LIS302DL*/
	    LIS302DL_InterruptStruct.Latch_Request = LIS302DL_INTERRUPTREQUEST_LATCHED;
	    LIS302DL_InterruptStruct.SingleClick_Axes = LIS302DL_CLICKINTERRUPT_Z_ENABLE;
	    LIS302DL_InterruptStruct.DoubleClick_Axes = LIS302DL_DOUBLECLICKINTERRUPT_Z_ENABLE;
	    LIS302DL_InterruptConfig(&LIS302DL_InterruptStruct);

	    GPIO_InitStructure.GPIO_Pin = GPIO_Pin_0;
	    GPIO_InitStructure.GPIO_Mode = GPIO_Mode_IN;
	    GPIO_Init(GPIOA, &GPIO_InitStructure);

	    int8_t przyspieszenie_x, przyspieszenie_y, przyspieszenie_z;
	    int j;
	    while(1)
	    {

	    	LIS302DL_Read(&przyspieszenie_x, LIS302DL_OUT_X_ADDR, 1);
	    	if(przyspieszenie_x>127)
	    	{
				przyspieszenie_x=przyspieszenie_x-1;
				przyspieszenie_x=(~przyspieszenie_x)&0xFF;
				przyspieszenie_x=-przyspieszenie_x;
	    	}

	        LIS302DL_Read(&przyspieszenie_y, LIS302DL_OUT_Y_ADDR, 1);
	        if(przyspieszenie_y>127)
	        {
	            przyspieszenie_y=przyspieszenie_y-1;
	            przyspieszenie_y=(~przyspieszenie_y)&0xFF;
	            przyspieszenie_y=-przyspieszenie_y;
	        }

	        LIS302DL_Read(&przyspieszenie_z, LIS302DL_OUT_Z_ADDR, 1);
	    	if(przyspieszenie_z>127)
	        {
				przyspieszenie_z=przyspieszenie_z-1;
				przyspieszenie_z=(~przyspieszenie_z)&0xFF;
				przyspieszenie_z=-przyspieszenie_z;
	        }

	       for(j=0;j<300000;j++){  //slowloop
	        }

	       //VCP_put_char((przyspieszenie_y)+128);
	       //test=przyspieszenie_y+128;

	       akcelerometrPakiet accPacket;
	        accPacket.command=ACC_COMMAND_TYPE;
	        accPacket.x=przyspieszenie_x;
	        accPacket.y=przyspieszenie_y+128;
	        accPacket.z=przyspieszenie_z;
	        accPacket.crc=CRC_START;

	        VCP_send_buffer(&accPacket, sizeof(akcelerometrPakiet));


	        przyciskPakiet buttonPacket;
	        buttonPacket.command=BUTTON_COMMAND_TYPE;
	        if(GPIO_ReadInputDataBit(GPIOA, GPIO_Pin_0))
	        	buttonPacket.butt1_state=BUTTON_CLICKED;
	        else
	        	buttonPacket.butt1_state=BUTTON_NO_CLICKED;
	        buttonPacket.butt2_state=BUTTON_NO_CLICKED;
	        buttonPacket.butt3_state=BUTTON_NO_CLICKED;
	        buttonPacket.butt4_state=BUTTON_NO_CLICKED;
	        buttonPacket.crc=CRC_START;
	        VCP_send_buffer(&buttonPacket, sizeof(przyciskPakiet));
	    }

	return 0;
}


void init()
{
	/* STM32F4 discovery LEDs */
	GPIO_InitTypeDef LED_Config;

	/* Always remember to turn on the peripheral clock...  If not, you may be up till 3am debugging... */
	RCC_AHB1PeriphClockCmd(RCC_AHB1Periph_GPIOD, ENABLE);
	LED_Config.GPIO_Pin = GPIO_Pin_12 | GPIO_Pin_13| GPIO_Pin_14| GPIO_Pin_15;
	LED_Config.GPIO_Mode = GPIO_Mode_OUT;
	LED_Config.GPIO_OType = GPIO_OType_PP;
	LED_Config.GPIO_Speed = GPIO_Speed_25MHz;
	LED_Config.GPIO_PuPd = GPIO_PuPd_NOPULL;
	GPIO_Init(GPIOD, &LED_Config);



	/* Setup SysTick or CROD! */
	if (SysTick_Config(SystemCoreClock / 1000))
	{
		ColorfulRingOfDeath();
	}


	/* Setup USB */
	USBD_Init(&USB_OTG_dev,
	            USB_OTG_FS_CORE_ID,
	            &USR_desc,
	            &USBD_CDC_cb,
	            &USR_cb);

	return;
}

/*
 * Call this to indicate a failure.  Blinks the STM32F4 discovery LEDs
 * in sequence.  At 168Mhz, the blinking will be very fast - about 5 Hz.
 * Keep that in mind when debugging, knowing the clock speed might help
 * with debugging.
 */
void ColorfulRingOfDeath(void)
{
	uint16_t ring = 1;
	while (1)
	{
		uint32_t count = 0;
		while (count++ < 500000);

		GPIOD->BSRRH = (ring << 12);
		ring = ring << 1;
		if (ring >= 1<<4)
		{
			ring = 1;
		}
		GPIOD->BSRRL = (ring << 12);
	}
}

/*
 * Interrupt Handlers
 */

void SysTick_Handler(void)
{
	ticker++;
	if (downTicker > 0)
	{
		downTicker--;
	}
}

void NMI_Handler(void)       {}
void HardFault_Handler(void) { ColorfulRingOfDeath(); }
void MemManage_Handler(void) { ColorfulRingOfDeath(); }
void BusFault_Handler(void)  { ColorfulRingOfDeath(); }
void UsageFault_Handler(void){ ColorfulRingOfDeath(); }
void SVC_Handler(void)       {}
void DebugMon_Handler(void)  {}
void PendSV_Handler(void)    {}

void OTG_FS_IRQHandler(void)
{
  USBD_OTG_ISR_Handler (&USB_OTG_dev);
}

void OTG_FS_WKUP_IRQHandler(void)
{
  if(USB_OTG_dev.cfg.low_power)
  {
    *(uint32_t *)(0xE000ED10) &= 0xFFFFFFF9 ;
    SystemInit();
    USB_OTG_UngateClock(&USB_OTG_dev);
  }
  EXTI_ClearITPendingBit(EXTI_Line18);
}
