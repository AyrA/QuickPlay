# QuickPlay

QuickPlay is a simple media player focused on playing a single file with a minimal user interface.

It's ideal to preview files.

## Features

### Tiny Window

The player occupies almost no space on the screen.

### Wide range of media file support

Thanks to libVLC this player supports almost all formats.

### Drag and Drop Support

Files can be dragged onto the application to play them

### Single Instance System

Only one QuickPlay instance is running at a time.
If a second instance is started,
it's closed again and the first one will play the media file you selected.

### Usability

- Clicking on the progress bar will seek to that position
- Double clicking the file name will open the directory of that file
- Keyboard controls

##Libraries

QuickPlay utilizes the [VideoLAN libVLC](https://www.videolan.org/vlc/libvlc.html),
which is an independent 3rd party component.

The library is bundled using [APak](https://github.com/AyrA/APak).

The minimum set for audio playback of all types on x86 and x64 is as follows:

	C:.
	├───x64
	│   │   libvlc.dll
	│   │   libvlccore.dll
	│   │   
	│   └───plugins
	│       ├───access
	│       │       libfilesystem_plugin.dll
	│       │       
	│       ├───audio_filter
	│       │       liba52tofloat32_plugin.dll
	│       │       liba52tospdif_plugin.dll
	│       │       libaudiobargraph_a_plugin.dll
	│       │       libaudio_format_plugin.dll
	│       │       libchorus_flanger_plugin.dll
	│       │       libcompressor_plugin.dll
	│       │       libdolby_surround_decoder_plugin.dll
	│       │       libdtstofloat32_plugin.dll
	│       │       libdtstospdif_plugin.dll
	│       │       libequalizer_plugin.dll
	│       │       libgain_plugin.dll
	│       │       libheadphone_channel_mixer_plugin.dll
	│       │       libkaraoke_plugin.dll
	│       │       libmono_plugin.dll
	│       │       libmpgatofixed32_plugin.dll
	│       │       libnormvol_plugin.dll
	│       │       libparam_eq_plugin.dll
	│       │       libremap_plugin.dll
	│       │       libsamplerate_plugin.dll
	│       │       libscaletempo_plugin.dll
	│       │       libsimple_channel_mixer_plugin.dll
	│       │       libspatializer_plugin.dll
	│       │       libspeex_resampler_plugin.dll
	│       │       libstereo_widen_plugin.dll
	│       │       libtrivial_channel_mixer_plugin.dll
	│       │       libugly_resampler_plugin.dll
	│       │       
	│       ├───audio_output
	│       │       libdirectsound_plugin.dll
	│       │       libwasapi_plugin.dll
	│       │       libwaveout_plugin.dll
	│       │       
	│       ├───codec
	│       │       liba52_plugin.dll
	│       │       libadpcm_plugin.dll
	│       │       libaes3_plugin.dll
	│       │       libaraw_plugin.dll
	│       │       libavcodec_plugin.dll
	│       │       libcc_plugin.dll
	│       │       libcdg_plugin.dll
	│       │       libcrystalhd_plugin.dll
	│       │       libcvdsub_plugin.dll
	│       │       libddummy_plugin.dll
	│       │       libdmo_plugin.dll
	│       │       libdts_plugin.dll
	│       │       libdvbsub_plugin.dll
	│       │       libdxva2_plugin.dll
	│       │       libedummy_plugin.dll
	│       │       libfaad_plugin.dll
	│       │       libflac_plugin.dll
	│       │       libg711_plugin.dll
	│       │       libjpeg_plugin.dll
	│       │       libkate_plugin.dll
	│       │       liblibass_plugin.dll
	│       │       liblibmpeg2_plugin.dll
	│       │       liblpcm_plugin.dll
	│       │       libmft_plugin.dll
	│       │       libmpeg_audio_plugin.dll
	│       │       libopus_plugin.dll
	│       │       libpng_plugin.dll
	│       │       libquicktime_plugin.dll
	│       │       librawvideo_plugin.dll
	│       │       libschroedinger_plugin.dll
	│       │       libscte27_plugin.dll
	│       │       libspeex_plugin.dll
	│       │       libspudec_plugin.dll
	│       │       libstl_plugin.dll
	│       │       libsubsdec_plugin.dll
	│       │       libsubstx3g_plugin.dll
	│       │       libsubsusf_plugin.dll
	│       │       libsvcdsub_plugin.dll
	│       │       libt140_plugin.dll
	│       │       libtheora_plugin.dll
	│       │       libtwolame_plugin.dll
	│       │       libuleaddvaudio_plugin.dll
	│       │       libvorbis_plugin.dll
	│       │       libvpx_plugin.dll
	│       │       libx264_plugin.dll
	│       │       libx265_plugin.dll
	│       │       libzvbi_plugin.dll
	│       │       
	│       └───demux
	│               libaiff_plugin.dll
	│               libasf_plugin.dll
	│               libau_plugin.dll
	│               libavi_plugin.dll
	│               libcaf_plugin.dll
	│               libdemuxdump_plugin.dll
	│               libdemux_cdg_plugin.dll
	│               libdemux_stl_plugin.dll
	│               libdiracsys_plugin.dll
	│               libes_plugin.dll
	│               libflacsys_plugin.dll
	│               libgme_plugin.dll
	│               libh264_plugin.dll
	│               libhevc_plugin.dll
	│               libimage_plugin.dll
	│               libmjpeg_plugin.dll
	│               libmkv_plugin.dll
	│               libmod_plugin.dll
	│               libmp4_plugin.dll
	│               libmpc_plugin.dll
	│               libmpgv_plugin.dll
	│               libnsc_plugin.dll
	│               libnsv_plugin.dll
	│               libnuv_plugin.dll
	│               libogg_plugin.dll
	│               libplaylist_plugin.dll
	│               libps_plugin.dll
	│               libpva_plugin.dll
	│               librawaud_plugin.dll
	│               librawdv_plugin.dll
	│               librawvid_plugin.dll
	│               libreal_plugin.dll
	│               libsid_plugin.dll
	│               libsmf_plugin.dll
	│               libsubtitle_plugin.dll
	│               libts_plugin.dll
	│               libtta_plugin.dll
	│               libty_plugin.dll
	│               libvc1_plugin.dll
	│               libvobsub_plugin.dll
	│               libvoc_plugin.dll
	│               libwav_plugin.dll
	│               libxa_plugin.dll
	│               
	└───x86
		│   libvlc.dll
		│   libvlccore.dll
		│   
		└───plugins
			│   plugins.dat
			│   
			├───access
			│       libfilesystem_plugin.dll
			│       
			├───audio_filter
			│       liba52tofloat32_plugin.dll
			│       liba52tospdif_plugin.dll
			│       libaudiobargraph_a_plugin.dll
			│       libaudio_format_plugin.dll
			│       libchorus_flanger_plugin.dll
			│       libcompressor_plugin.dll
			│       libdolby_surround_decoder_plugin.dll
			│       libdtstofloat32_plugin.dll
			│       libdtstospdif_plugin.dll
			│       libequalizer_plugin.dll
			│       libgain_plugin.dll
			│       libheadphone_channel_mixer_plugin.dll
			│       libkaraoke_plugin.dll
			│       libmono_plugin.dll
			│       libmpgatofixed32_plugin.dll
			│       libnormvol_plugin.dll
			│       libparam_eq_plugin.dll
			│       libremap_plugin.dll
			│       libsamplerate_plugin.dll
			│       libscaletempo_plugin.dll
			│       libsimple_channel_mixer_plugin.dll
			│       libspatializer_plugin.dll
			│       libspeex_resampler_plugin.dll
			│       libstereo_widen_plugin.dll
			│       libtrivial_channel_mixer_plugin.dll
			│       libugly_resampler_plugin.dll
			│       
			├───audio_output
			│       libdirectsound_plugin.dll
			│       libwasapi_plugin.dll
			│       libwaveout_plugin.dll
			│       
			├───codec
			│       liba52_plugin.dll
			│       libadpcm_plugin.dll
			│       libaes3_plugin.dll
			│       libaraw_plugin.dll
			│       libavcodec_plugin.dll
			│       libcc_plugin.dll
			│       libcdg_plugin.dll
			│       libcrystalhd_plugin.dll
			│       libcvdsub_plugin.dll
			│       libddummy_plugin.dll
			│       libdmo_plugin.dll
			│       libdts_plugin.dll
			│       libdvbsub_plugin.dll
			│       libdxva2_plugin.dll
			│       libedummy_plugin.dll
			│       libfaad_plugin.dll
			│       libflac_plugin.dll
			│       libg711_plugin.dll
			│       libjpeg_plugin.dll
			│       libkate_plugin.dll
			│       liblibass_plugin.dll
			│       liblibmpeg2_plugin.dll
			│       liblpcm_plugin.dll
			│       libmft_plugin.dll
			│       libmpeg_audio_plugin.dll
			│       libopus_plugin.dll
			│       libpng_plugin.dll
			│       libqsv_plugin.dll
			│       libquicktime_plugin.dll
			│       librawvideo_plugin.dll
			│       libschroedinger_plugin.dll
			│       libscte27_plugin.dll
			│       libspeex_plugin.dll
			│       libspudec_plugin.dll
			│       libstl_plugin.dll
			│       libsubsdec_plugin.dll
			│       libsubstx3g_plugin.dll
			│       libsubsusf_plugin.dll
			│       libsvcdsub_plugin.dll
			│       libt140_plugin.dll
			│       libtheora_plugin.dll
			│       libtwolame_plugin.dll
			│       libuleaddvaudio_plugin.dll
			│       libvorbis_plugin.dll
			│       libvpx_plugin.dll
			│       libx264_plugin.dll
			│       libx265_plugin.dll
			│       libzvbi_plugin.dll
			│       
			└───demux
					libaiff_plugin.dll
					libasf_plugin.dll
					libau_plugin.dll
					libavi_plugin.dll
					libcaf_plugin.dll
					libdemuxdump_plugin.dll
					libdemux_cdg_plugin.dll
					libdemux_stl_plugin.dll
					libdiracsys_plugin.dll
					libes_plugin.dll
					libflacsys_plugin.dll
					libgme_plugin.dll
					libh264_plugin.dll
					libhevc_plugin.dll
					libimage_plugin.dll
					libmjpeg_plugin.dll
					libmkv_plugin.dll
					libmod_plugin.dll
					libmp4_plugin.dll
					libmpc_plugin.dll
					libmpgv_plugin.dll
					libnsc_plugin.dll
					libnsv_plugin.dll
					libnuv_plugin.dll
					libogg_plugin.dll
					libplaylist_plugin.dll
					libps_plugin.dll
					libpva_plugin.dll
					librawaud_plugin.dll
					librawdv_plugin.dll
					librawvid_plugin.dll
					libreal_plugin.dll
					libsid_plugin.dll
					libsmf_plugin.dll
					libsubtitle_plugin.dll
					libts_plugin.dll
					libtta_plugin.dll
					libty_plugin.dll
					libvc1_plugin.dll
					libvobsub_plugin.dll
					libvoc_plugin.dll
					libwav_plugin.dll
					libxa_plugin.dll

You are free to delete codec DLL files you are not interested in to reduce the file size.
If you configure the Project for 32 bit only, you can discard the x64 tree branch.
If you add the video and UI DLL files, the player will show a window with the video content if you play a video file.