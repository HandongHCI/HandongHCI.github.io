from phue import Bridge
'''
from googleapiclient.discovery import build
from httplib2 import Http
from oauth2client import file, client, tools
'''

import random
import csv
import time
import bluetooth
import textwrap
import struct
import collections

'''
# Uploading data to Google Sheet
SCOPES = 'https://www.googleapis.com/auth/spreadsheets'
store = file.Storage('token.json')
creds = store.get()
if not creds or creds.invalid:
    flow = client.flow_from_clientsecrets('credentials.json', SCOPES)
    creds = tools.run_flow(flow, store)
service = build('sheets', 'v4', http=creds.authorize(Http()))

# Call the Sheets API
SPREADSHEET_ID = '1G2Z38CgSWzWwGWox1w5E3ie2FfF6CI8q0BDQ_-CF6kE'
RANGE_NAME_Medval = 'Sheet1!A2'
RANGE_NAME_Attval = 'Sheet1!B2'
'''

#MindwaveDataPointReader--------------------------
class MindwaveDataPointReader:
    def __init__(self, address=None):
        self._mindwaveMobileRawReader = MindwaveMobileRawReader(address=address)
        self._dataPointQueue = collections.deque()

    def start(self):
        self._mindwaveMobileRawReader.connectToMindWaveMobile()

    def isConnected(self):
        return self._mindwaveMobileRawReader.isConnected()

    def readNextDataPoint(self):
        if (not self._moreDataPointsInQueue()):
            self._putNextDataPointsInQueue()
        return self._getDataPointFromQueue()

    def _moreDataPointsInQueue(self):
        return len(self._dataPointQueue) > 0

    def _getDataPointFromQueue(self):
        return self._dataPointQueue.pop();

    def _putNextDataPointsInQueue(self):
        dataPoints = self._readDataPointsFromOnePacket()
        self._dataPointQueue.extend(dataPoints)

    def _readDataPointsFromOnePacket(self):
        self._goToStartOfNextPacket()
        payloadBytes, checkSum = self._readOnePacket()
        if (not self._checkSumIsOk(payloadBytes, checkSum)):
            print("checksum of packet was not correct, discarding packet...")
            return self._readDataPointsFromOnePacket();
        else:
            dataPoints = self._readDataPointsFromPayload(payloadBytes)
        self._mindwaveMobileRawReader.clearAlreadyReadBuffer()
        return dataPoints;

    def _goToStartOfNextPacket(self):
        while(True):
            byte = self._mindwaveMobileRawReader.getByte()
            if (byte == MindwaveMobileRawReader.START_OF_PACKET_BYTE):  # need two of these bytes at the start..
                byte = self._mindwaveMobileRawReader.getByte()
                if (byte == MindwaveMobileRawReader.START_OF_PACKET_BYTE):
                    # now at the start of the packet..
                    return;

    def _readOnePacket(self):
            payloadLength = self._readPayloadLength();
            payloadBytes, checkSum = self._readPacket(payloadLength);
            return payloadBytes, checkSum

    def _readPayloadLength(self):
        payloadLength = self._mindwaveMobileRawReader.getByte()
        return payloadLength

    def _readPacket(self, payloadLength):
        payloadBytes = self._mindwaveMobileRawReader.getBytes(payloadLength)
        checkSum = self._mindwaveMobileRawReader.getByte()
        return payloadBytes, checkSum

    def _checkSumIsOk(self, payloadBytes, checkSum):
        sumOfPayload = sum(payloadBytes)
        lastEightBits = sumOfPayload % 256
        invertedLastEightBits = self._computeOnesComplement(lastEightBits) #1's complement!
        return invertedLastEightBits == checkSum;

    def _computeOnesComplement(self, lastEightBits):
        return ~lastEightBits + 256

    def _readDataPointsFromPayload(self, payloadBytes):
        payloadParser = MindwavePacketPayloadParser(payloadBytes)
        return payloadParser.parseDataPoints();

#MindwaveDataPoints-------------------
class DataPoint:
    def __init__(self, dataValueBytes):
        self._dataValueBytes = dataValueBytes

class UnknownDataPoint(DataPoint):
    def __init__(self, dataValueBytes):
        DataPoint.__init__(self, dataValueBytes)
        self.unknownPoint = self._dataValueBytes[0]

    def __str__(self):
        retMsgString = "Unknown OpCode. Value: {}".format(self.unknownPoint)
        return retMsgString

class PoorSignalLevelDataPoint(DataPoint):
    def __init__(self, dataValueBytes):
        DataPoint.__init__(self, dataValueBytes)
        self.amountOfNoise = self._dataValueBytes[0];

    def headSetHasContactToSkin(self):
        return self.amountOfNoise < 200;

    def __str__(self):
        poorSignalLevelString = "Poor Signal Level: " + str(self.amountOfNoise)
        if (not self.headSetHasContactToSkin()):
            poorSignalLevelString += " - NO CONTACT TO SKIN"
        return poorSignalLevelString

class AttentionDataPoint(DataPoint):
    def __init__(self, _dataValueBytes):
        DataPoint.__init__(self, _dataValueBytes)
        self.attentionValue = self._dataValueBytes[0]

    def __str__(self):
        return "Attention Level: " + str(self.attentionValue)

class MeditationDataPoint(DataPoint):
    def __init__(self, _dataValueBytes):
        DataPoint.__init__(self, _dataValueBytes)
        self.meditationValue = self._dataValueBytes[0]

    def __str__(self):
        return "Meditation Level: " + str(self.meditationValue)

class BlinkDataPoint(DataPoint):
    def __init__(self, _dataValueBytes):
        DataPoint.__init__(self, _dataValueBytes)
        self.blinkValue = self._dataValueBytes[0]

    def __str__(self):
        return "Blink Level: " + str(self.blinkValue)

class RawDataPoint(DataPoint):
    def __init__(self, dataValueBytes):
        DataPoint.__init__(self, dataValueBytes)
        self.rawValue = self._readRawValue()

    def _readRawValue(self):
        firstByte = self._dataValueBytes[0]
        secondByte = self._dataValueBytes[1]
        # TODO(check if this is correct iwth soem more tests..
        # and see http://stackoverflow.com/questions/5994307/bitwise-operations-in-python
        rawValue = firstByte * 256 + secondByte;
        if rawValue >= 32768:
            rawValue -= 65536
        return rawValue # hope this is correct ;)

    def __str__(self):
        return "Raw Value: " + str(self.rawValue)

class EEGPowersDataPoint(DataPoint):
    def __init__(self, dataValueBytes):
        DataPoint.__init__(self, dataValueBytes)
        self._rememberEEGValues();

    def _rememberEEGValues(self):
        self.delta = self._convertToBigEndianInteger(self._dataValueBytes[0:3]);
        self.theta = self._convertToBigEndianInteger(self._dataValueBytes[3:6]);
        self.lowAlpha = self._convertToBigEndianInteger(self._dataValueBytes[6:9]);
        self.highAlpha = self._convertToBigEndianInteger(self._dataValueBytes[9:12]);
        self.lowBeta = self._convertToBigEndianInteger(self._dataValueBytes[12:15]);
        self.highBeta = self._convertToBigEndianInteger(self._dataValueBytes[15:18]);
        self.lowGamma = self._convertToBigEndianInteger(self._dataValueBytes[18:21]);
        self.midGamma = self._convertToBigEndianInteger(self._dataValueBytes[21:24]);


    def _convertToBigEndianInteger(self, threeBytes):
        # TODO(check if this is correct iwth soem more tests..
        # and see http://stackoverflow.com/questions/5994307/bitwise-operations-in-python
        # only use first 16 bits of second number, not rest inc ase number is negative, otherwise
        # python would take all 1s before this bit...
        # same with first number, only take first 8 bits...
        bigEndianInteger = (threeBytes[0] << 16) |\
         (((1 << 16) - 1) & (threeBytes[1] << 8)) |\
          ((1 << 8) - 1) & threeBytes[2]
        return bigEndianInteger

    def __str__(self):
        return """EEG Powers:
                delta: {self.delta}
                theta: {self.theta}
                lowAlpha: {self.lowAlpha}
                highAlpha: {self.highAlpha}
                lowBeta: {self.lowBeta}
                highBeta: {self.highBeta}
                lowGamma: {self.lowGamma}
                midGamma: {self.midGamma}
                """.format(self = self)


#MindwaveMobileRawReader--------------------

class MindwaveMobileRawReader:
    START_OF_PACKET_BYTE = 0xaa;
    def __init__(self, address=None):
        self._buffer = [];
        self._bufferPosition = 0;
        self._isConnected = False;
        self._mindwaveMobileAddress = address

    def connectToMindWaveMobile(self):
        # First discover mindwave mobile address, then connect.
        # Headset address of my headset was'9C:B7:0D:72:CD:02';
        # not sure if it really can be different?
        # now discovering address because of https://github.com/robintibor/python-mindwave-mobile/issues/4
        if (self._mindwaveMobileAddress is None):
            self._mindwaveMobileAddress = self._findMindwaveMobileAddress()
        if (self._mindwaveMobileAddress is not None):
            print ("Discovered Mindwave Mobile...")
            self._connectToAddress(self._mindwaveMobileAddress)
        else:
            self._printErrorDiscoveryMessage()

    def _findMindwaveMobileAddress(self):
        nearby_devices = bluetooth.discover_devices(lookup_names = True)
        for address, name in nearby_devices:
            if (name == "MindWave Mobile"):
                return address
        return None

    def _connectToAddress(self, mindwaveMobileAddress):
        self.mindwaveMobileSocket = bluetooth.BluetoothSocket(bluetooth.RFCOMM)
        while (not self._isConnected):
            try:
                self.mindwaveMobileSocket.connect(
                    (mindwaveMobileAddress, 1))
                self._isConnected = True
            except bluetooth.btcommon.BluetoothError as error:
                print("Could not connect: ", error, "; Retrying in 5s...")
                time.sleep(5)


    def isConnected(self):
        return self._isConnected

    def _printErrorDiscoveryMessage(self):
         print((textwrap.dedent("""\
                    Could not discover Mindwave Mobile. Please make sure the
                    Mindwave Mobile device is in pairing mode and your computer
                    has bluetooth enabled.""").replace("\n", " ")))

    def _readMoreBytesIntoBuffer(self, amountOfBytes):
        newBytes = self._readBytesFromMindwaveMobile(amountOfBytes)
        self._buffer += newBytes

    def _readBytesFromMindwaveMobile(self, amountOfBytes):
        missingBytes = amountOfBytes
        # receivedBytes = ""  #py2
        receivedBytes = b''   #py3

        # Sometimes the socket will not send all the requested bytes
        # on the first request, therefore a loop is necessary...
        while(missingBytes > 0):
            receivedBytes += self.mindwaveMobileSocket.recv(missingBytes)
            missingBytes = amountOfBytes - len(receivedBytes)
        return receivedBytes;

    def peekByte(self):
        self._ensureMoreBytesCanBeRead();
        return ord(self._buffer[self._bufferPosition])

    def getByte(self):
        self._ensureMoreBytesCanBeRead(100);
        return self._getNextByte();

    def  _ensureMoreBytesCanBeRead(self, amountOfBytes):
        if (self._bufferSize() <= self._bufferPosition + amountOfBytes):
            self._readMoreBytesIntoBuffer(amountOfBytes)

    def _getNextByte(self):
        # nextByte = ord(self._buffer[self._bufferPosition]) #py2
        nextByte = self._buffer[self._bufferPosition]   #py3
        self._bufferPosition += 1;
        return nextByte;

    def getBytes(self, amountOfBytes):
        self._ensureMoreBytesCanBeRead(amountOfBytes);
        return self._getNextBytes(amountOfBytes);

    def _getNextBytes(self, amountOfBytes):
        # nextBytes = list(map(ord, self._buffer[self._bufferPosition: self._bufferPosition + amountOfBytes])) #py2
        nextBytes = list(self._buffer[self._bufferPosition: self._bufferPosition + amountOfBytes]) #py3
        self._bufferPosition += amountOfBytes
        return nextBytes

    def clearAlreadyReadBuffer(self):
        self._buffer = self._buffer[self._bufferPosition : ]
        self._bufferPosition = 0;

    def _bufferSize(self):
        return len(self._buffer);

#payloadParser--------------------

EXTENDED_CODE_BYTE = 0x55

class MindwavePacketPayloadParser:

    def __init__(self, payloadBytes):
        self._payloadBytes = payloadBytes
        self._payloadIndex = 0

    def parseDataPoints(self):
        dataPoints = []
        while (not self._atEndOfPayloadBytes()):
            dataPoint = self._parseOneDataPoint()
            dataPoints.append(dataPoint)
        return dataPoints

    def _atEndOfPayloadBytes(self):
        return self._payloadIndex == len(self._payloadBytes)

    def _parseOneDataPoint(self):
        dataRowCode = self._extractDataRowCode();
        dataRowValueBytes = self._extractDataRowValueBytes(dataRowCode)
        return self._createDataPoint(dataRowCode, dataRowValueBytes)

    def _extractDataRowCode(self):
        return self._ignoreExtendedCodeBytesAndGetRowCode()

    def _ignoreExtendedCodeBytesAndGetRowCode(self):
        # EXTENDED_CODE_BYTES seem not to be used according to
        # http://wearcam.org/ece516/mindset_communications_protocol.pdf
        # (August 2012)
        # so we ignore them
        byte = self._getNextByte()
        while (byte == EXTENDED_CODE_BYTE):
            byte = self._getNextByte()
        dataRowCode = byte
        return dataRowCode

    def _getNextByte(self):
        nextByte = self._payloadBytes[self._payloadIndex]
        self._payloadIndex += 1
        return nextByte

    def _getNextBytes(self, amountOfBytes):
        nextBytes = self._payloadBytes[self._payloadIndex : self._payloadIndex + amountOfBytes]
        self._payloadIndex += amountOfBytes
        return nextBytes

    def _extractDataRowValueBytes(self, dataRowCode):
        lengthOfValueBytes = self._extractLengthOfValueBytes(dataRowCode)
        dataRowValueBytes = self._getNextBytes(lengthOfValueBytes)
        return dataRowValueBytes

    def _extractLengthOfValueBytes(self, dataRowCode):
        # If code is one of the mysterious initial code values
        # return before the extended code check
        if dataRowCode == 0xBA or dataRowCode == 0xBC:
            return 1

        dataRowHasLengthByte = dataRowCode > 0x7f
        if (dataRowHasLengthByte):
            return self._getNextByte()
        else:
            return 1

    def _createDataPoint(self, dataRowCode, dataRowValueBytes):
        if (dataRowCode == 0x02):
            return PoorSignalLevelDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0x04):
            return AttentionDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0x05):
            return MeditationDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0x16):
            return BlinkDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0x80):
            return RawDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0x83):
            return EEGPowersDataPoint(dataRowValueBytes)
        elif (dataRowCode == 0xba or dataRowCode == 0xbc):
            return UnknownDataPoint(dataRowValueBytes)
        else:
            assert False

#example-----------------------------------------------------

# connect to HUE
b = Bridge("192.168.0.4")
#If running for the first time, press button on bridge and run with b.connect() uncommented
b.connect()
b.set_light(1,'on', True)


'''
meddata = open('medVal.csv', 'w', encoding='utf-8', newline='')
medcsv = csv.writer(meddata)

attdata = open('attVal.csv', 'w', encoding='utf-8', newline='')
attcsv = csv.writer(attdata)

wavedata = open('waveVal.csv', 'w', encoding='utf-8', newline='')
wavecsv = csv.writer(wavedata)
'''
sleepdata = open('sleepVal.csv', 'w', encoding='utf-8', newline='')
sleepcsv = csv.writer(sleepdata)

if __name__ == '__main__':
    mindwaveDataPointReader = MindwaveDataPointReader()
    mindwaveDataPointReader.start()
    if (mindwaveDataPointReader.isConnected()):
        #for i in range(1000):
        while(True):
            dataPoint = mindwaveDataPointReader.readNextDataPoint()
            now = time.localtime()
            s = "%04d-%02d-%02d %02d:%02d:%02d" % (now.tm_year, now.tm_mon, now.tm_mday, now.tm_hour, now.tm_min, now.tm_sec)
            if (not dataPoint.__class__ is RawDataPoint):
                #print(dir(dataPoint))
                if hasattr(dataPoint, 'unknownPoint'):
                    flag = 0

                if hasattr(dataPoint, 'meditationValue'):
                    #medVal = "N/A"
                    print("meditation: ", dataPoint.meditationValue)
                    medVal = dataPoint.meditationValue
                    if medVal>65:
                        b.set_light(1, 'xy', [0.21, 0.72])
                    elif medVal>40:
                        b.set_light(1, 'xy', [0.45,0.55])
                    else:
                        b.set_light(1, 'xy', [0.68, 0.32])
                    #b.set_light(5,'bri', medVal)
                    #medcsv.writerow([s,medVal])

                if hasattr(dataPoint, 'attentionValue'):
                    #attVal = "N/A"
                    print("attention: ", dataPoint.attentionValue)
                    attVal = dataPoint.attentionValue
                    #b.set_light(5,'bri', attVal)
                    #attcsv.writerow([s,attVal])

                if hasattr(dataPoint, 'delta'):
                    flag = 1
                    DVal = dataPoint.delta
                    HAVal = dataPoint.highAlpha
                    HBVal = dataPoint.highBeta
                    LAVal = dataPoint.lowAlpha
                    LBVal = dataPoint.lowBeta
                    LGVal = dataPoint.lowGamma
                    MGVal = dataPoint.midGamma
                    TVal = dataPoint.theta
                    #wavecsv.writerow([s,DVal,TVal,LAVal,HAVal,LBVal,HBVal,LGVal,MGVal])

                #if flag == 1:
                    # Creating CSV file which includes time and mindwave data
                    #sleepcsv.writerow([s,medVal,attVal,DVal,TVal,LAVal,HAVal,LBVal,HBVal,LGVal,MGVal])

                    #service.spreadsheets().values().update(spreadsheetId = SPREADSHEET_ID,range = RANGE_NAME_Medval, valueInputOption = 'USER_ENTERED',body = [medVal]).execute()
                    #service.spreadsheets().values().update(spreadsheetId = SPREADSHEET_ID,range = RANGE_NAME_Attval, valueInputOption = 'USER_ENTERED',body = [attVal]).execute()

                # Activate when you needs intervals between getting values.
                #time.sleep(5)

    else:
        print((textwrap.dedent("""\
            Exiting because the program could not connect
            to the Mindwave Mobile device.""").replace("\n", " ")))
